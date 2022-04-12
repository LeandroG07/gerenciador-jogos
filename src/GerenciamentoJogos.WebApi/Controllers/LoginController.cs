using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using GerenciamentoJogos.Domain.Models;
using GerenciamentoJogos.Domain.Services;
using GerenciamentoJogos.Domain.Services.Validation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GerenciamentoJogos.WebApi.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;

        public LoginController(IServiceValidate serviceValidate, ILoginService loginService) : base(serviceValidate)
        {
            _loginService = loginService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Entrar(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            var login = _loginService.Logar(loginModel);
            if (login == null)
            {
                return Response();
            }

            var claims = new List<Claim>()
            { 
                new Claim(ClaimTypes.Name, loginModel.Usuario),
                new Claim(ClaimTypes.NameIdentifier, login.NomeUsuario),
                new Claim(ClaimTypes.Sid, login.IdLogin.ToString())
            };

            var userIdentity = new ClaimsIdentity(claims, "login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Emprestimo");
        }

        public async Task<IActionResult> Sair()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
