using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDD_Sample_dotNet.Models;

namespace TDD_Sample_dotNet.Services
{
    public interface IUserService
    {
        public Task<ActionResult<IEnumerable<User>>> GetAllUsers();
        public Task<ActionResult<User>> GetUserById(int id);
        public Task<ActionResult<User>> AddUser(User user);
        public Task<bool> UpdateUSer(User user);
        public Task<bool> RemoveUserById(int id);
    }
}