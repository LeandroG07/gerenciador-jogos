using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Models;
using GerenciamentoJogos.Domain.Services.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Services
{
    public interface IAmigoService
    {

        AmigoModel Obter(int id);

        IEnumerable<AmigoModel> Listar();

        void Inserir(AmigoModel amigoModel);

        void Atualizar(AmigoModel amigoModel);

        void Excluir(int id);

    }
}
