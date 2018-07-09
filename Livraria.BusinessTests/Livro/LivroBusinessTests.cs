using FluentAssertions;
using Livraria.Business.DTO;
using Livraria.Business.Livro;
using Livraria.Repository;
using NSubstitute;
using NUnit.Framework;
using System;
using LivroModel = Livraria.Repository.Models.Livro;

namespace Livraria.BusinessTests.Livro
{
    [TestFixture]
    public class LivroBusinessTests
    {
        private const string ERRO = "Um erro ocorreu";

        private ILivroRepository _livroRepository;
        private ILivroMapper _livroMapper;
        private ILivroBusiness _livroBusiness;

        [SetUp]
        public void Setup()
        {
            _livroRepository = Substitute.For<ILivroRepository>();
            _livroMapper = Substitute.For<ILivroMapper>();

            _livroBusiness = new LivroBusiness(_livroRepository, _livroMapper);
        }

        [Test]
        public void Deve_obter_lista_de_livro_dto()
        {
            _livroRepository.GetAll().Returns(LivroFake.ObterListaLivroFake());
            _livroMapper.ModelToDTOMapper(Arg.Any<LivroModel>()).Returns(LivroFake.ObterLivroDTOFake());

            var expected = LivroFake.ObterListaLivroDtoFake();
            var actual = _livroBusiness.Listar();

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Deve_inserir_livro()
        {
            var livroDtoFake = LivroFake.ObterLivroDTOFake();

            _livroMapper.DTOToModelMapper(Arg.Any<LivroDTO>()).Returns(LivroFake.ObterLivroFake());

            _livroBusiness.Inserir(livroDtoFake);

            _livroMapper.Received(1).DTOToModelMapper(Arg.Any<LivroDTO>());
            _livroRepository.Received(1).Insert(Arg.Any<LivroModel>());
        }

        [Test]
        public void Deve_obter_livro_dto()
        {
            var expected = LivroFake.ObterLivroDTOFake();

            _livroMapper.ModelToDTOMapper(Arg.Any<LivroModel>()).Returns(expected);
            _livroRepository.Get(Arg.Any<int>()).Returns(LivroFake.ObterLivroFake());

            var actual = _livroBusiness.Obter(LivroFake.ID_LIVRO);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Deve_editar_livro()
        {
            var livroDtoFake = LivroFake.ObterLivroDTOFake();

            _livroMapper.DTOToModelMapper(Arg.Any<LivroDTO>()).Returns(LivroFake.ObterLivroFake());

            _livroBusiness.Editar(livroDtoFake);

            _livroMapper.Received(1).DTOToModelMapper(Arg.Any<LivroDTO>());
            _livroRepository.Received(1).Update(Arg.Any<LivroModel>());
        }

        [Test]
        public void Deve_deletar_livro()
        {
            _livroRepository.Get(Arg.Any<int>()).Returns(LivroFake.ObterLivroFake());

            _livroBusiness.Deletar(LivroFake.ID_LIVRO);

            _livroRepository.Received(1).Get(Arg.Any<int>());
            _livroRepository.Received(1).Delete(Arg.Any<LivroModel>());
        }

        [Test]
        public void Deve_lancar_excecao_quando_houver_erro_para_listar()
        {
            _livroRepository.When(x => x.GetAll()).Do(x => throw new Exception(ERRO));

            var exception = Assert.Throws<Exception>(() => _livroBusiness.Listar());

            exception.Message.Should().Be($"Não foi possível obter os livros cadastrados! Erro:{ERRO}");
        }

        [Test]
        public void Deve_lancar_excecao_quando_houver_erro_para_inserir()
        {
            var livroDtoFake = LivroFake.ObterLivroDTOFake();

            _livroMapper.When(x => x.DTOToModelMapper(Arg.Any<LivroDTO>())).Do(x => throw new Exception(ERRO));

            var exception = Assert.Throws<Exception>(() => _livroBusiness.Inserir(livroDtoFake));

            exception.Message.Should().Be($"Não foi possível inserir o livro informado! Erro:{ERRO}");
        }

        [Test]
        public void Deve_lancar_excecao_quando_houver_erro_para_obter()
        {
            _livroRepository.When(x => x.Get(Arg.Any<int>())).Do(x => throw new Exception(ERRO));

            var exception = Assert.Throws<Exception>(() => _livroBusiness.Obter(LivroFake.ID_LIVRO));

            exception.Message.Should().Be($"Não foi possível obter o livro! Erro:{ERRO}");
        }

        [Test]
        public void Deve_lancar_excecao_quando_houver_erro_para_editar()
        {
            var livroDtoFake = LivroFake.ObterLivroDTOFake();

            _livroMapper.When(x => x.DTOToModelMapper(Arg.Any<LivroDTO>())).Do(x => throw new Exception(ERRO));

            var exception = Assert.Throws<Exception>(() => _livroBusiness.Editar(livroDtoFake));

            exception.Message.Should().Be($"Não foi possível editar o livro! Erro:{ERRO}");
        }

        [Test]
        public void Deve_lancar_excecao_quando_houver_erro_para_deletar()
        {
            _livroRepository.When(x => x.Get(Arg.Any<int>())).Do(x => throw new Exception(ERRO));

            var exception = Assert.Throws<Exception>(() => _livroBusiness.Deletar(LivroFake.ID_LIVRO));

            exception.Message.Should().Be($"Não foi possível deletar o livro! Erro:{ERRO}");
        }
    }
}