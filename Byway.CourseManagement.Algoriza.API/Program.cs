
using Byway.CourseManagement.Algoriza.API.Errors.Configuration;
using Byway.CourseManagement.Algoriza.API.Middlewares;
using Byway.Infrastructure.DependancyInjection;
using Microsoft.AspNetCore.Builder;
using Scalar.AspNetCore;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Byway.CourseManagement.Algoriza.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(configure =>
            {
                configure.JsonSerializerOptions.PropertyNamingPolicy= JsonNamingPolicy.CamelCase;
                configure.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            builder.Services.AddInfrastructureServices(builder.Configuration);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Confiure Api Invalid Model State Response
            builder.Services.AddApiInvalidModelStateConfiguration();

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapScalarApiReference();
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
