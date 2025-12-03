namespace MembersMicroservice.Models
{
    public class MembersModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; } = true;
        public int LimiteEmprestimos { get; set; } = 3;
        public int EmprestimosAtivos { get; set; } = 0;
    }
}
