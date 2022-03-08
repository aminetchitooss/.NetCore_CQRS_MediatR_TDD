using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDD_Sample_dotNet.Models;
using MediatR;
using TDD_Sample_dotNet.Commands;
using System.Threading;
using TDD_Sample_dotNet.Services;

namespace TDD_Sample_dotNet.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User toAdd = new User();
            toAdd.Age = request.Age;
            toAdd.Email = request.Email;
            toAdd.Name = request.Name;
            toAdd.UserName = request.UserName;
            return await _userService.AddUser(toAdd);

        }
    }
}

