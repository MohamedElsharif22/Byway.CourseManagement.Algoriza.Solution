
using Byway.Application.DependancyInjection;
using Byway.Application.Mapping;
using Byway.CourseManagement.Algoriza.API.Errors.Configuration;
using Byway.CourseManagement.Algoriza.API.Extensions;
using Byway.CourseManagement.Algoriza.API.Helpers;
using Byway.CourseManagement.Algoriza.API.Middlewares;
using Byway.Domain.Entities;
using Byway.Infrastructure.DependancyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Byway.CourseManagement.Algoriza.API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(configure =>
            {
                configure.JsonSerializerOptions.PropertyNamingPolicy= JsonNamingPolicy.CamelCase;
                configure.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddDbContextServices(builder.Configuration);

            builder.Services.AddInfrastructureServices();

            builder.Services.AddApplicationServices();

            builder.Services.AddAuthenticationServices(builder.Configuration);

            builder.Services.AddMemoryCache();

            //builder.Services.AddIdentity<User, IdentityRole>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Confiure Api Invalid Model State Response
            builder.Services.AddApiInvalidModelStateConfiguration();

            // add cors policies
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("wepPolicy", policyConfig =>
                {
                    policyConfig.WithOrigins(builder.Configuration["FrontendOrigins:AdminHosted"], 
                                             builder.Configuration["FrontendOrigins:AdminLocal"])
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            await app.MiagrateAndSeedDatabasesAsync();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapScalarApiReference();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.MapControllers();

            app.UseCors("wepPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.Run();
        }
    }
}
