using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
