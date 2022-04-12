using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciamentoJogos.Domain.Models
{
    public class ValidationViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
