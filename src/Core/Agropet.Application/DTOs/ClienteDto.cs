using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.DTOs
{
    public class ClienteDto
    {
        public string Nome { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public string CPFUsuarioCadastro { get; set; } = null!;
    }
}
