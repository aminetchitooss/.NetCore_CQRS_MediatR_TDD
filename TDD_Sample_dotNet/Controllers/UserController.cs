using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDD_Sample_dotNet.Models;
using TDD_Sample_dotNet.Services;
using TDD_Sample_dotNet.Queries;
using MediatR;
using TDD_Sample_dotNet.Commands;

namespace TDD_Sample_dotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;

        public UserController(IUserService userService, IMediator mediator)
        {
            _userService = userService;
            _mediator = mediator;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            var query = new GetAllUsersQuery();
            var vResults = await _mediator.Send(query);
            return Ok(vResults);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var query = new GetUserByIdQuery(id);
            var vResults = await _mediator.Send(query);

            if (vResults == null)
            {
                return NotFound();
            }
            return Ok(vResults);
        }

        // PUT: api/User/5
        // Update the user
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            User vUserAdded = await _mediator.Send(command);

            if (vUserAdded == null)
                return BadRequest("Problem in updating");

            return NoContent();
        }

        // POST: api/User
        // Create the user
        [HttpPost]
        public async Task<ActionResult> PostUser([FromBody] CreateUserCommand command)
        {
            var vUserAdded = await _mediator.Send(command);
            return CreatedAtAction("GetUser", new { id = vUserAdded.Id }, vUserAdded);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var command = new DeleteUserCommand(id);
            var isDeletedOk = await _mediator.Send(command);

            if (!isDeletedOk)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
