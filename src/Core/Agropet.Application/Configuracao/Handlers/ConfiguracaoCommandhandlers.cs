using Agropet.Application.Common.Response;
using Agropet.Application.Configuracao.Commands;
using Agropet.Domain.Interfaces;
using MediatR;
using System.Net;

namespace Agropet.Application.Configuracao.Handlers;

public class AtualizarConfiguracaoCommandhandlers(IConfiguracaoRepository _configuracaoRepository, IUnitOfWork _unitOfWork) : IRequestHandler<AtualizarConfiguracaoCommand, Resposta>
{
    public async Task<Resposta> Handle(AtualizarConfiguracaoCommand request, CancellationToken cancellationToken)
    {
        var config = await _configuracaoRepository.ObterPorNome(request.ENomeConfiguracao);
        if (config == null)
            return new Resposta((int)HttpStatusCode.BadRequest);

        config.AtualizarValor(request.Valor);

        _configuracaoRepository.Atualizar(config);
        await _unitOfWork.Commit(cancellationToken);

        return new Resposta((int)HttpStatusCode.OK);
    }
}
