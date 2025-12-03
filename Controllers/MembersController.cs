using Microsoft.AspNetCore.Mvc;
using MembersMicroservice.Models;
using MembersMicroservice.Services;

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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var member = await _service.GetById(id);
            if (member == null) return NotFound();
            return Ok(member);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MembersModel model)
        {
            var created = await _service.Create(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}/incrementar")]
        public async Task<IActionResult> Incrementar(int id)
        {
            var sucesso = await _service.IncrementarEmprestimos(id);
            if (!sucesso) return BadRequest("Não foi possível atualizar.");
            return Ok("Atualizado com sucesso.");
        }
    }
}
