using Microsoft.AspNetCore.Mvc;
using MembersMicroservice.Model;
using Members.DTO.MembersDTO;
using MembersService.Services;


namespace MembersService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly MembersService _service;

        public MembersController(MembersService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var member = _service.GetById(id);
            return member == null ? NotFound() : Ok(member);
        }

        [HttpPost]
        public IActionResult Create(MembersDTO member) => Ok(_service.Create(member));

        [HttpPut("{id}")]
        public IActionResult Update(int id, MembersDTO member)
        {
            return _service.Update(id, member) ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _service.Delete(id) ? Ok() : NotFound();
        }
    }
}
