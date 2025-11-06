using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.DTOs
{
    //TODO: Criar diferentes DTOs, conforme necessidade. ex: criarUsuarioDto...
    public class UsuarioDto
    {
        public string Nome { get; set; } = null!;
        public string CPF { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}
