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
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUserService _userService;

        public DeleteUserByIdCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.RemoveUserById(request.Id);
        }
    }
}
