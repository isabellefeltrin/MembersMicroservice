
using Members.DTO.MembersDTO;
using Members.Repositories;
using MembersMicroservice.Database;
using MembersMicroservice.Model;
using System.Linq;

namespace MembersMicroservice.Services
{
    public class MembersService
    {
        private readonly AppDbContext _context;

        public MembersService(AppDbContext context)
        {
            _context = context;
        }

        public List<MembersModel> GetAll()
        {
            return _context.MembersModel.ToList();
        }

        public MembersModel GetById(int id)
        {
            return _context.MembersModel.FirstOrDefault(m => m.Id == id);
        }

        public MembersModel Create(MembersDTO dto)
        {
            var member = new MembersModel
            {
                Name = dto.Name,
                Email = dto.Email,
            };

            _context.MembersModel.Add(member);
            _context.SaveChanges();
            return member;
        }

        public bool Update(int id, MembersDTO updated)
        {
            var member = _context.MembersModel.FirstOrDefault(m => m.Id == id);
            if (member == null) return false;

            member.Name = updated.Name;
            member.Email = updated.Email;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var member = _context.MembersModel.FirstOrDefault(m => m.Id == id);
            if (member == null) return false;

            _context.MembersModel.Remove(member);
            _context.SaveChanges();
            return true;
        }
    }
}

