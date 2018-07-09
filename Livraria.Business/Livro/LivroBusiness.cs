using Livraria.Business.DTO;
using Livraria.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Business.Livro
{
    public class LivroBusiness : ILivroBusiness
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroMapper _livroMapper;

        public LivroBusiness()
            : this(new LivroRepository(), new LivroMapper())
        {
        }

        public LivroBusiness(ILivroRepository livroRepository, ILivroMapper livroMapper)
        {
            _livroRepository = livroRepository;
            _livroMapper = livroMapper;
        }

        public IList<LivroDTO> Listar()
        {
            try
            {
                var listaLivroDto = new List<LivroDTO>();
                var livros = _livroRepository.GetAll().OrderBy(l => l.Titulo).ToList();

                livros.ForEach(livro => listaLivroDto.Add(_livroMapper.ModelToDTOMapper(livro)));

                return listaLivroDto;
            }
            catch (Exception erro)
            {
                throw new Exception($"Não foi possível obter os livros cadastrados! Erro:{erro.Message}");
            }
        }

        public void Inserir(LivroDTO livroDto)
        {
            try
            {
                var livro = _livroMapper.DTOToModelMapper(livroDto);
                _livroRepository.Insert(livro);
            }
            catch (Exception erro)
            {
                throw new Exception($"Não foi possível inserir o livro informado! Erro:{erro.Message}");
            }
        }

        public LivroDTO Obter(int id)
        {
            try
            {
                var livro = _livroRepository.Get(id);

                return _livroMapper.ModelToDTOMapper(livro);
            }
            catch (Exception erro)
            {
                throw new Exception($"Não foi possível obter o livro! Erro:{erro.Message}");
            }
        }

        public void Editar(LivroDTO livroDto)
        {
            try
            {
                var livro = _livroMapper.DTOToModelMapper(livroDto);
                _livroRepository.Update(livro);
            }
            catch (Exception erro)
            {
                throw new Exception($"Não foi possível editar o livro! Erro:{erro.Message}");
            }
        }

        public void Deletar(int id)
        {
            try
            {
                var livro = _livroRepository.Get(id);

                _livroRepository.Delete(livro);
            }
            catch (Exception erro)
            {
                throw new Exception($"Não foi possível deletar o livro! Erro:{erro.Message}");
            }
        }
    }
}
