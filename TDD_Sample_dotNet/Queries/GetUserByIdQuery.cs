using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDD_Sample_dotNet.Models;
using MediatR;

namespace TDD_Sample_dotNet.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}

