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
    public class JogoController : BaseController
    {
        public readonly IJogoService _jogoService;

        public JogoController(IServiceValidate serviceValidate, IJogoService JogoService) : base(serviceValidate)
        {
            _jogoService = JogoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Jogos = _jogoService.Listar();
            return Response(Jogos);
        }

        [HttpGet]
        public IActionResult Inserir()
        {
            return Response();
        }

        [HttpPost]
        public IActionResult Inserir(JogoModel JogoModel)
        {
            _jogoService.Inserir(JogoModel);
            var Jogos = _jogoService.Listar();
            return Response("Index", Jogos);
        }

        [HttpGet]
        public IActionResult Atualizar(int idJogo)
        {
            var Jogo = _jogoService.Obter(idJogo);
            return Response(Jogo);
        }

        [HttpPost]
        public IActionResult Atualizar(JogoModel JogoModel)
        {
            _jogoService.Atualizar(JogoModel);
            var Jogos = _jogoService.Listar();
            return Response("Index", Jogos);
        }

        [HttpGet]
        public IActionResult Excluir(int idJogo)
        {
            var Jogo = _jogoService.Obter(idJogo);
            return Response(Jogo);
        }

        [HttpPost]
        public IActionResult Excluir(JogoModel model)
        {
            _jogoService.Excluir(model.IdJogo);
            var Jogos = _jogoService.Listar();
            return Response("Index", Jogos);
        }
    }
}
