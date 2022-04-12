using GerenciamentoJogos.Domain.Models;
using GerenciamentoJogos.Domain.Services.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoJogos.WebApi.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IServiceValidate _serviceValidate;

        public BaseController(IServiceValidate serviceValidate)
        {
            _serviceValidate = serviceValidate;
        }

        protected new IActionResult Response(string viewName, object data)
        {      
            
            if (_serviceValidate.Validacao)
            {
                var erros = new StringBuilder();
                _serviceValidate.Validacoes.ToList().ForEach(_ => erros.Append(string.Format("{0}.{1}", _.Descricao, Environment.NewLine)));
                return View("Validation", new ValidationViewModel() { RequestId = erros.ToString() });
            }
            if (_serviceValidate.Sucesso)
            {
                if (data != null && !string.IsNullOrEmpty(viewName))
                {
                    return View(viewName, data);
                }
                else if (data != null)
                {
                    return View(data);
                }
                else if (!string.IsNullOrEmpty(viewName))
                {
                    return View(viewName);
                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                var erros = new StringBuilder();
                _serviceValidate.Erros.ToList().ForEach(_ => erros.Append(string.Format("{0}.{1}", _.Descricao, Environment.NewLine)));                
                return View("Error", new ErrorViewModel() { RequestId = erros.ToString() });
            }
        }

        protected new IActionResult Response(string viewName)
        {
            return Response(viewName, null);
        }

        protected new IActionResult Response(object data)
        {
            return Response(null, data);
        }

        protected new IActionResult Response()
        {
            return Response(null, null);
        }

    }
}
