using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        Cliente Obter(string cpf);
    }
}
