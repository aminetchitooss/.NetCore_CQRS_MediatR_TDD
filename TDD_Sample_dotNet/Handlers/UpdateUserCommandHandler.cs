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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            User toAdd = new User();
            toAdd.Id = request.Id;
            toAdd.Age = request.Age;
            toAdd.Email = request.Email;
            toAdd.Name = request.Name;
            toAdd.UserName = request.UserName;
            return await _userService.UpdateUSer(toAdd);

        }
    }
}

