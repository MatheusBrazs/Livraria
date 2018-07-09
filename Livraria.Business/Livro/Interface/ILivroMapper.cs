using Livraria.Business.DTO;
using LivroModel = Livraria.Repository.Models.Livro;

namespace Livraria.Business.Livro
{
    public interface ILivroMapper
    {
        LivroModel DTOToModelMapper(LivroDTO livroDto);
        LivroDTO ModelToDTOMapper(LivroModel livroModel);
    }
}