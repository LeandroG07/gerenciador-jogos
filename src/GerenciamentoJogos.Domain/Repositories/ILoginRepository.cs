using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Repositories
{
    public interface ILoginRepository
    {

        Login Logar(Login login);

    }
}
