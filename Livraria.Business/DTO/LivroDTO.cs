namespace Livraria.Business.DTO
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoEdicao { get; set; }
        public string Genero { get; set; }
        public int QuantidadeExemplares { get; set; }
        public string Editora { get; set; }
    }
}
