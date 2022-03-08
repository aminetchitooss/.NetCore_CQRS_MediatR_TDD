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
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            bool isUpdateOk = await _userService.UpdateUSer(user);

            if (!isUpdateOk)
                return BadRequest("Problem in updating");

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var vUserAdded = await _userService.AddUser(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var isDeletedOk = await _userService.RemoveUserById(id);
            if (!isDeletedOk)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
