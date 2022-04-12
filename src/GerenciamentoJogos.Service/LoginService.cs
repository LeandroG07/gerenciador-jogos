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
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly IServiceValidate _serviceValidate;
        private readonly ILoginRepository _loginRepository;

        public LoginService(IMapper mapper,
                            IServiceValidate serviceValidate,
                            ILoginRepository loginRepository)
        {
            _mapper = mapper;
            _serviceValidate = serviceValidate;
            _loginRepository = loginRepository;
        }

        public Login Logar(LoginModel loginModel)
        {       
            try
            {
                var login = _mapper.Map<LoginModel, Login>(loginModel);
                var loginRepository = _loginRepository.Logar(login);
                if (loginRepository == null)
                {
                    _serviceValidate.AdicionarValidacao("Usuário não encontrado");
                    return null;
                }

                return loginRepository;
            }
            catch (Exception ex)
            {
                _serviceValidate.AdicionarErro("Falha ao Logar", ex.Message);
                return null;
            }        
        }
    }
}
