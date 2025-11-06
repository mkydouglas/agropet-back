using Agropet.Application.DTOs;
using Agropet.Application.Response;
using Agropet.Application.Services;
using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Interfaces;

public interface IVendaService : IServiceBase<Venda>
{
    Task<Resposta> Cadastrar(VendaDTO vendaDTO);
}
