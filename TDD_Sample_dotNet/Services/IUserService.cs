using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDD_Sample_dotNet.Models;

namespace TDD_Sample_dotNet.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<User> AddUser(User user);
        public Task<User> UpdateUSer(User user);
        public Task<bool> RemoveUserById(int id);
    }
}