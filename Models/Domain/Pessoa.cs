namespace PataAmiga.Models.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Interesses { get; set; }
        public DateTime DataNascimnto { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
