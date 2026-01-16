using Agropet.Application.Common.Response;
using Agropet.Application.Configuracao.Queries;
using Agropet.Application.Configuracao.Responses;
using Agropet.Domain.Extensions;
using Agropet.Domain.Interfaces;
using MediatR;
using System.Drawing;
using System.Net;

namespace Agropet.Application.Configuracao.Handlers;

public class ConfiguracaoQueryHandlers(IConfiguracaoRepository _configuracaoRepository) : IRequestHandler<ListarConfiguracaoQuery, Resposta>
{
    public async Task<Resposta> Handle(ListarConfiguracaoQuery request, CancellationToken cancellationToken)
    {
        var configs = await _configuracaoRepository.ListarAsync();
        var response = configs.Select(c => new ListarConfiguracaoResponse(c.Id, c.Nome, c.Nome.GetDescription(), c.Valor));

        return new Resposta((int)HttpStatusCode.OK, response);
    }
}
