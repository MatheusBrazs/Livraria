using Livraria.Business.DTO;
using System.Collections.Generic;
using LivroModel = Livraria.Repository.Models.Livro;

namespace Livraria.BusinessTests.Livro
{
    public class LivroFake
    {
        public const int ID_LIVRO = 1;
        private const int ANO_EDICAO = 2018;
        private const int QUANTIDADE_EXEMPLARES = 10;
        private const string AUTOR = "Autor Teste";
        private const string EDITORA = "Editora Teste";
        private const string GENERTO = "Gênero Teste";
        private const string TITULO = "Título teste";

        public static LivroDTO ObterLivroDTOFake()
        {
            return new LivroDTO
            {
                Id = ID_LIVRO,
                AnoEdicao = ANO_EDICAO,
                Autor = AUTOR,
                Editora = EDITORA,
                Genero = GENERTO,
                QuantidadeExemplares = QUANTIDADE_EXEMPLARES,
                Titulo = TITULO
            };
        }

        public static LivroModel ObterLivroFake()
        {
            return new LivroModel
            {
                Id = ID_LIVRO,
                AnoEdicao = ANO_EDICAO,
                Autor = AUTOR,
                Editora = EDITORA,
                Genero = GENERTO,
                QuantidadeExemplares = QUANTIDADE_EXEMPLARES,
                Titulo = TITULO
            };
        }

        public static IList<LivroDTO> ObterListaLivroDtoFake()
        {
            return new List<LivroDTO>
            {
                ObterLivroDTOFake()
            };
        }

        public static IList<LivroModel> ObterListaLivroFake()
        {
            return new List<LivroModel>
            {
                ObterLivroFake()
            };
        }
    }
}
