using Agropet.Application.DTOs;
using Agropet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agropet.Application.Interfaces;

public interface IProdutoService : IServiceBase<Produto>
{
    int Cadastrar(ProdutoDTO produtoDTO);
    Produto? ObterPorCodigoBarras(long codigoBarras);
    new List<ListarProdutoDTO> Listar();
}
