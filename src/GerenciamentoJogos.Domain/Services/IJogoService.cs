using GerenciamentoJogos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Services
{
    public interface IJogoService
    {
        JogoModel Obter(int id);

        IEnumerable<JogoModel> Listar();

        void Inserir(JogoModel jogoModel);

        void Atualizar(JogoModel jogoModel);

        void Excluir(int id);
    }
}
