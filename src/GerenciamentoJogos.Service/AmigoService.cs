using AutoMapper;
using GerenciamentoJogos.Domain.Entities;
using GerenciamentoJogos.Domain.Models;
using GerenciamentoJogos.Domain.Repositories;
using GerenciamentoJogos.Domain.Services;
using GerenciamentoJogos.Domain.Services.Validation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace GerenciamentoJogos.Service
{
    public class AmigoService : ServiceValidate, IAmigoService
    {
        private readonly IMapper _mapper;
        private readonly IServiceValidate _serviceValidate;
        private readonly IAmigoRepository _amigoRepository;

        public AmigoService(IMapper mapper,
                            IServiceValidate serviceValidate,
                            IAmigoRepository amigoRepository)
        {
            _mapper = mapper;
            _serviceValidate = serviceValidate;
            _amigoRepository = amigoRepository;
        }
        
        public AmigoModel Obter(int idAmigo)
        {
            try
            {
                var amigo = _mapper.Map<Amigo, AmigoModel>(_amigoRepository.Obter(idAmigo));
                return amigo;
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Obter Amigo", ex.Message);
                return null;
            }
        }

        public IEnumerable<AmigoModel> Listar()
        {
            try
            {                
                var amigosModel = _mapper.Map<IEnumerable<Amigo>, IEnumerable<AmigoModel>>(_amigoRepository.Listar());
                return amigosModel;
            }
            catch(Exception ex)
            {                
                _serviceValidate.AdicionarErro("Falha ao Listar Amigos", ex.Message);                
                return null;
            }            
        }

        public void Inserir(AmigoModel amigoModel)
        {
            try
            {
                var amigo = _mapper.Map<AmigoModel, Amigo>(amigoModel);
                _amigoRepository.Inserir(amigo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Inserir Amigo", ex.Message);                
            }
        }

        public void Atualizar(AmigoModel amigoModel)
        {
            try
            {
                var amigo = _mapper.Map<AmigoModel, Amigo>(amigoModel);
                _amigoRepository.Atualizar(amigo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Atualizar Amigo", ex.Message);
            }
        }

        public void Excluir(int idAmigo)
        {
            try
            {
                _amigoRepository.Excluir(idAmigo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Excluir Amigo", ex.Message);
            }
        }

    }
}
