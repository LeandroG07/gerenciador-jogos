using AutoMapper;
using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Models;
using GerenciamentoJogos.Domain.Repositories;
using GerenciamentoJogos.Domain.Services;
using GerenciamentoJogos.Domain.Services.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Service
{
    public class JogoService : ServiceValidate, IJogoService
    {
        private readonly IMapper _mapper;
        private readonly IServiceValidate _serviceValidate;
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IMapper mapper,
                            IServiceValidate serviceValidate,
                            IJogoRepository jogoRepository)
        {
            _mapper = mapper;
            _serviceValidate = serviceValidate;
            _jogoRepository = jogoRepository;
        }

        public JogoModel Obter(int idJogo)
        {
            try
            {
                var Jogo = _mapper.Map<Jogo, JogoModel>(_jogoRepository.Obter(idJogo));
                return Jogo;
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Obter Jogo", ex.Message);
                return null;
            }
        }

        public IEnumerable<JogoModel> Listar()
        {
            try
            {
                var JogosModel = _mapper.Map<IEnumerable<Jogo>, IEnumerable<JogoModel>>(_jogoRepository.Listar());
                return JogosModel;
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Listar Jogos", ex.Message);
                return null;
            }
        }

        public void Inserir(JogoModel JogoModel)
        {
            try
            {
                var Jogo = _mapper.Map<JogoModel, Jogo>(JogoModel);
                _jogoRepository.Inserir(Jogo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Inserir Jogo", ex.Message);
            }
        }

        public void Atualizar(JogoModel JogoModel)
        {
            try
            {
                var Jogo = _mapper.Map<JogoModel, Jogo>(JogoModel);
                _jogoRepository.Atualizar(Jogo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Atualizar Jogo", ex.Message);
            }
        }

        public void Excluir(int idJogo)
        {
            try
            {
                _jogoRepository.Excluir(idJogo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Excluir Jogo", ex.Message);
            }
        }
    }
}
