using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoJogos.Domain.Models;
using GerenciamentoJogos.Domain.Services;
using GerenciamentoJogos.Domain.Services.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoJogos.WebApi.Controllers
{
    [Authorize]
    public class AmigoController : BaseController
    {
        public readonly IAmigoService _amigoService;        

        public AmigoController(IServiceValidate serviceValidate, IAmigoService amigoService) : base(serviceValidate)
        {            
            _amigoService = amigoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var amigos = _amigoService.Listar();
            return Response(amigos);
        }

        [HttpGet]
        public IActionResult Inserir()
        {
            return Response();
        }

        [HttpPost]
        public IActionResult Inserir(AmigoModel amigoModel)
        {
            _amigoService.Inserir(amigoModel);
            var amigos = _amigoService.Listar();
            return Response("Index", amigos);
        }

        [HttpGet]
        public IActionResult Atualizar(int idAmigo)
        {
            var amigo = _amigoService.Obter(idAmigo);
            return Response(amigo);
        }

        [HttpPost]
        public IActionResult Atualizar(AmigoModel amigoModel)
        {
            _amigoService.Atualizar(amigoModel);
            var amigos = _amigoService.Listar();
            return Response("Index", amigos);
        }

        [HttpGet]
        public IActionResult Excluir(int idAmigo)
        {
            var amigo = _amigoService.Obter(idAmigo);
            return Response(amigo);
        }

        [HttpPost]
        public IActionResult Excluir(AmigoModel model)
        {
            _amigoService.Excluir(model.IdAmigo);
            var amigos = _amigoService.Listar();
            return Response("Index", amigos);
        }

    }
}