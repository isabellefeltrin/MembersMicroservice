using Members.DTO.MembersDTO;
using MembersMicroservice.Model;
using MembersMicroservice.Repositories;
using MembersMicroservice.Services;
using Microsoft.AspNetCore.Mvc;

namespace MembersMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly MembersService _service;

        public MembersController(MembersService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var member = _service.GetById(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        [HttpPatch("{id:int}/active-loans")]
        public IActionResult UpdateActiveLoans(int id, [FromBody] int newActiveLoans)
        {
            _service.UpdateActiveLoans(id, newActiveLoans);
            return NoContent();
        }
    }
}
