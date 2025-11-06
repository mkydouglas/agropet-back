using Agropet.Application.DTOs;
using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Interfaces
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario Obter(string cpf);
        Usuario Atualizar(UsuarioDto usuarioDto);
    }
}
