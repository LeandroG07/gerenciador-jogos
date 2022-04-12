using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoJogos.Domain.Models;
using GerenciamentoJogos.Domain.Services;
using GerenciamentoJogos.Domain.Services.Validation;
using GerenciamentoJogos.WebApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoJogos.WebApi.Controllers
{
    [Authorize]
    public class EmprestimoController : BaseController
    {
        public readonly IEmprestimoService _emprestimoService;
        public readonly IJogoService _jogoService;
        public readonly IAmigoService _amigoService;

        public EmprestimoController(IServiceValidate serviceValidate, 
                                    IEmprestimoService emprestimoService, 
                                    IJogoService jogoService,
                                    IAmigoService amigoService) : base(serviceValidate)
        {
            _emprestimoService = emprestimoService;
            _jogoService = jogoService;
            _amigoService = amigoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var emprestimos = _emprestimoService.Listar();
            return Response(emprestimos);
        }        

        [HttpGet]
        public IActionResult Inserir()
        {            
            EmprestimoViewModel emprestimoViewModel = new EmprestimoViewModel()
            {
                JogosModel = _jogoService.Listar(),
                AmigosModel = _amigoService.Listar()
            };
            return Response(emprestimoViewModel);
        }

        [HttpPost]
        public IActionResult Inserir(EmprestimoModel emprestimoModel)
        {
            _emprestimoService.Inserir(emprestimoModel);
            var emprestimos = _emprestimoService.Listar();
            return Response("Index", emprestimos);
        }

        [HttpGet]
        public IActionResult Atualizar(int idEmprestimo)
        {
            EmprestimoViewModel emprestimoViewModel = new EmprestimoViewModel()
            {
                EmprestimoModel = _emprestimoService.Obter(idEmprestimo),
                JogosModel = _jogoService.Listar(),
                AmigosModel = _amigoService.Listar()
            };
            
            return Response(emprestimoViewModel);
        }

        [HttpPost]
        public IActionResult Atualizar(EmprestimoModel emprestimoModel)
        {
            _emprestimoService.Atualizar(emprestimoModel);
            var emprestimos = _emprestimoService.Listar();
            return Response("Index", emprestimos);
        }

        [HttpGet]
        public IActionResult Receber(int idEmprestimo)
        {
            EmprestimoViewModel emprestimoViewModel = new EmprestimoViewModel()
            {
                EmprestimoModel = _emprestimoService.Obter(idEmprestimo),
                JogosModel = _jogoService.Listar(),
                AmigosModel = _amigoService.Listar()
            };

            return Response(emprestimoViewModel);
        }

        [HttpPost]
        public IActionResult Receber(EmprestimoModel emprestimoModel)
        {            
            _emprestimoService.Receber(emprestimoModel);
            var emprestimos = _emprestimoService.Listar();
            return Response("Index", emprestimos);            
        }

    }
}
