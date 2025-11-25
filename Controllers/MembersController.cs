using Microsoft.AspNetCore.Mvc;
using MembersMicroservice.Model;
using Members.DTO.MembersDTO;
using MembersMicroservice.Repositories;

namespace MembersMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly MembersRepository _repository;

        public MembersController(MembersRepository repository)
        {
            _repository = repository;
        }

        private MembersModel MapToModel(MembersDTO dto)
        {
            var model = new MembersModel();

             model.Name = dto.Name;
             model.Email = dto.Email;


            return model;
        }

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_repository.GetAll());

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var member = _repository.GetById(id);
            return member == null ? NotFound() : Ok(member);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MembersDTO member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = MapToModel(member);
            _repository.Create(entity);

            return Ok(entity);
        }


        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] MembersDTO member)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = _repository.GetById(id);
            if (existing == null)
                return NotFound();

            var entity = MapToModel(member);

            _repository.Update(entity);

            return NoContent();
        }
    }
}
