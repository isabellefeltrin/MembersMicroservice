using Microsoft.EntityFrameworkCore;
using MembersMicroservice.Data;
using MembersMicroservice.Models;

namespace MembersMicroservice.Repositories
{
    public class MembersRepository
    {
        private readonly AppDbContext _context;

        public MembersRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MembersModel>> GetAll()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<MembersModel?> GetById(int id)
        {
            return await _context.Members.FindAsync(id);
        }

        public async Task<MembersModel> Create(MembersModel model)
        {
            _context.Members.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Update(MembersModel model)
        {
            _context.Members.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
