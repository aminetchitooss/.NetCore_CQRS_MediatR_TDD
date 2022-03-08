using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDD_Sample_dotNet.Models;
using MediatR;

namespace TDD_Sample_dotNet.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public CreateUserCommand(string name, string email, string userName, int age)
        {
            Name = name;
            Email = email;
            UserName = userName;
            Age = age;
        }
    }
}

