using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDD_Sample_dotNet.Models;
using MediatR;

namespace TDD_Sample_dotNet.Commands
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}

