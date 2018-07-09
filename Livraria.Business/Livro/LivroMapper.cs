using Livraria.Business.DTO;
using LivroModel = Livraria.Repository.Models.Livro;

namespace Livraria.Business.Livro
{
    public class LivroMapper : ILivroMapper
    {
        public LivroDTO ModelToDTOMapper(LivroModel livroModel)
        {
            return new LivroDTO
            {
                Id = livroModel.Id,
                AnoEdicao = livroModel.AnoEdicao,
                Autor = livroModel.Autor,
                Editora = livroModel.Editora,
                Genero = livroModel.Genero,
                QuantidadeExemplares = livroModel.QuantidadeExemplares,
                Titulo = livroModel.Titulo
            };
        }

        public LivroModel DTOToModelMapper(LivroDTO livroDto)
        {
            return new LivroModel
            {
                Id = livroDto.Id,
                AnoEdicao = livroDto.AnoEdicao,
                Autor = livroDto.Autor,
                Editora = livroDto.Editora,
                Genero = livroDto.Genero,
                QuantidadeExemplares = livroDto.QuantidadeExemplares,
                Titulo = livroDto.Titulo
            };
        }
    }
}
