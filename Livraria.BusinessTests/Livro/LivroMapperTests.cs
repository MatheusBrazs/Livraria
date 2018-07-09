using FluentAssertions;
using Livraria.Business.Livro;
using NUnit.Framework;

namespace Livraria.BusinessTests.Livro
{
    [TestFixture]
    public class LivroMapperTests
    {
        private ILivroMapper _livroMapper;

        [SetUp]
        public void Setup()
        {
            _livroMapper = new LivroMapper();
        }

        [Test]
        public void Deve_obter_livro_dto_do_model()
        {
            var expected = LivroFake.ObterLivroDTOFake();
            var actual = _livroMapper.ModelToDTOMapper(LivroFake.ObterLivroFake());

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Deve_obter_livro_model_do_dto()
        {
            var expected = LivroFake.ObterLivroFake();
            var actual = _livroMapper.DTOToModelMapper(LivroFake.ObterLivroDTOFake());

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
