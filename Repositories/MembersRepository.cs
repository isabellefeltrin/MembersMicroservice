

using MembersMicroservice.Database;
using MembersMicroservice.Model;
using System.Collections.Generic;
using System.Linq;

namespace MembersMicroservice.Repositories;



    public class MembersRepository
    {
        private readonly AppDbContext _context;

        public MembersRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<MembersModel> GetAll()
        {
            return _context.MembersModel.ToList();
        }

        public MembersModel GetById(int id)
        {
            return _context.MembersModel.FirstOrDefault(x => x.Id == id);
        }

        public void Create(MembersModel book)
        {
            _context.MembersModel.Add(book);
            _context.SaveChanges();
        }

        public void Update(MembersModel book)
        {
            _context.MembersModel.Update(book);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }


