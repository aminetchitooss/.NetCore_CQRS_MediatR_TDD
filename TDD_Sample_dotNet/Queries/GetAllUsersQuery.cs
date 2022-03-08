using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TDD_Sample_dotNet.Models;
using MediatR;

namespace TDD_Sample_dotNet.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {

    }
}

