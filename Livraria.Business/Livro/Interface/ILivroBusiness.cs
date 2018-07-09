using System.Collections.Generic;
using Livraria.Business.DTO;

namespace Livraria.Business.Livro
{
    public interface ILivroBusiness
    {
        void Deletar(int id);
        void Editar(LivroDTO livroDto);
        void Inserir(LivroDTO livroDto);
        IList<LivroDTO> Listar();
        LivroDTO Obter(int id);
    }
}