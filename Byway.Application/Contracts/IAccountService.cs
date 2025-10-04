using Byway.Application.DTOs.Account;
using Byway.Application.DTOs.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Contracts
{
    public interface IAccountService
    {
        Task<(UserResponse?, IEnumerable<string>?)> RegisterAsync(RegisterRequest request);
        Task<(UserResponse?, string?)> LoginAsync(LoginRequest request);
        Task<(UserResponse?, string?)> GoogleAuthAsync(GoogleAuthRequest request);

    }
}
