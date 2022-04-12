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
    public class EmprestimoService : ServiceValidate, IEmprestimoService
    {
        private readonly IMapper _mapper;
        private readonly IServiceValidate _serviceValidate;
        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(IMapper mapper,
                            IServiceValidate serviceValidate,
                            IEmprestimoRepository emprestimoRepository)
        {
            _mapper = mapper;
            _serviceValidate = serviceValidate;
            _emprestimoRepository = emprestimoRepository;
        }

        public void Atualizar(EmprestimoModel emprestimoModel)
        {
            try
            {
                var emprestimo = _mapper.Map<EmprestimoModel, Emprestimo>(emprestimoModel);
                _emprestimoRepository.Atualizar(emprestimo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Atualizar Emprestimo", ex.Message);
            }
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(EmprestimoModel emprestimoModel)
        {
            try
            {
                var emprestimo = _mapper.Map<EmprestimoModel, Emprestimo>(emprestimoModel);
                _emprestimoRepository.Inserir(emprestimo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Inserir Emprestimo", ex.Message);
            }
        }

        public IEnumerable<EmprestimoModel> Listar()
        {
            try
            {
                var emprestimoModel = _mapper.Map<IEnumerable<Emprestimo>, IEnumerable<EmprestimoModel>>(_emprestimoRepository.Listar());
                return emprestimoModel;
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Listar Emprestimos", ex.Message);
                return null;
            }
        }

        public EmprestimoModel Obter(int idEmprestimo)
        {
            try
            {
                var emprestimoModel = _mapper.Map<Emprestimo, EmprestimoModel>(_emprestimoRepository.Obter(idEmprestimo));
                return emprestimoModel;
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Obter Emprestimo", ex.Message);
                return null;
            }
        }

        public void Receber(EmprestimoModel emprestimoModel)
        {
            try
            {
                var emprestimo = _mapper.Map<EmprestimoModel, Emprestimo>(emprestimoModel);
                emprestimo.DataDevolvido = DateTime.MaxValue;
                _emprestimoRepository.Receber(emprestimo);
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Receber Emprestimo", ex.Message);
            }
        }
        
    }
}
