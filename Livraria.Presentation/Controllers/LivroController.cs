using Livraria.Business.DTO;
using Livraria.Business.Livro;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Livraria.Presentation.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroBusiness _livroBusiness;

        public LivroController()
        {
            _livroBusiness = new LivroBusiness();
        }

        [HttpGet]
        public string Index()
        {
            try
            {
                return JsonConvert.SerializeObject(
                    _livroBusiness.Listar(), 
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
            catch (Exception erro)
            {
                return erro.Message;
            }
        }

        [HttpPost]
        public string Criar(LivroDTO livroDto)
        {
            try
            {
                _livroBusiness.Inserir(livroDto);
                return "true";
            }
            catch (Exception erro)
            {
                return erro.Message;
            }
        }

        [HttpGet]
        public string Detalhar(int id)
        {
            try
            {
                return JsonConvert.SerializeObject(
                    _livroBusiness.Obter(id),
                    new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
            catch (Exception erro)
            {
                return erro.Message;
            }
        }

        [HttpPut]
        public string Editar(LivroDTO livro)
        {
            try
            {
                _livroBusiness.Editar(livro);
                return "true";
            }
            catch (Exception erro)
            {
                return erro.Message;
            }
        }

        [HttpDelete]
        public string Deletar(int id)
        {
            try
            {
                _livroBusiness.Deletar(id);
                return "true";
            }
            catch (Exception erro)
            {
                return erro.Message;
            }
        }
    }
}
