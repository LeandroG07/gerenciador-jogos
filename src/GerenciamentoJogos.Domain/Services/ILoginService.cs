using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Services
{
    public interface ILoginService
    {

        Login Logar(LoginModel login);

    }
}
