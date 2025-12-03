using MembersMicroservice.Models;
using MembersMicroservice.Repositories;

namespace MembersMicroservice.Services
{
    public class MembersService
    {
        private readonly MembersRepository _repo;

        public MembersService(MembersRepository repo)
        {
            _repo = repo;
        }

        public Task<List<MembersModel>> GetAll() => _repo.GetAll();

        public Task<MembersModel?> GetById(int id) => _repo.GetById(id);

        public Task<MembersModel> Create(MembersModel model)
        {
            return _repo.Create(model);
        }

        public async Task<bool> IncrementarEmprestimos(int memberId)
        {
            var member = await _repo.GetById(memberId);
            if (member == null) return false;

            if (!member.Ativo) return false;

            if (member.EmprestimosAtivos >= member.LimiteEmprestimos)
                return false;

            member.EmprestimosAtivos++;
            await _repo.Update(member);
            return true;
        }
    }
}
