
using Livraria.Repository.Models;

namespace Livraria.Repository
{
    public class LivroRepository : EfRepositoryBase<Livro, LivrariaContext> , ILivroRepository
    {
        public LivroRepository()
            : base(new LivrariaContext())
        {
        }
    }
}
