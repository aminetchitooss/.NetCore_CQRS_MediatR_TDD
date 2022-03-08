using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDD_Sample_dotNet.Models;
using MediatR;

namespace TDD_Sample_dotNet.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public UpdateUserCommand(string name, string email, string userName, int age, int id)
        {
            Name = name;
            Email = email;
            UserName = userName;
            Age = age;
            Id = id;
        }
    }
}

