using Agropet.Application._Common.DTOs;
using Agropet.Application.Common.Interfaces;
using Agropet.Application.Compra.Commands;
using Agropet.Application.Compra.Handlers;
using Agropet.Application.Compra.Inputs;
using Agropet.Application.Compra.Services;
using Agropet.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Agropet.Application.Tests.Compra.Handlers;

public class CompraCommandHandlersTest
{
    [Fact]
    public async Task Deve_retornar_bad_request_quando_usuario_nao_existir()
    {
        // Arrange
        var usuarioRepository = new Mock<IUsuarioRepository>();
        var fornecedorService = new Mock<IFornecedorService>();
        var estoqueRepository = new Mock<IEstoqueRepository>();
        var processadorCompra = new Mock<IProcessadorCompra>();

        usuarioRepository
            .Setup(x => x.ObterAsync(It.IsAny<int>()))
            .ReturnsAsync((Domain.Entities.Usuario?)null);

        var handler = new CadastrarCompraCommandHandler(
            usuarioRepository.Object,
            estoqueRepository.Object,
            fornecedorService.Object,
            processadorCompra.Object
        );

        var command = new CadastrarCompraCommand
        {
            NumeroNotaFiscal = "",
            FornecedorInput = new FornecedorInput
            {
                CNPJ = ""
            },
            ItensComprados = new List<ItemCompraInput>
            {

            },
            UserId = 1
        };

        // Act
        var resposta = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal((int)HttpStatusCode.BadRequest, resposta.StatusCode);
        Assert.False(resposta.Success);

        processadorCompra.Verify(
            x => x.ProcessarAsync(It.IsAny<CadastrarCompraInput>(), It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async Task Deve_retornar_bad_request_quando_fornecedor_nao_existir()
    {
        var usuarioRepository = new Mock<IUsuarioRepository>();
        var fornecedorService = new Mock<IFornecedorService>();
        var estoqueRepository = new Mock<IEstoqueRepository>();
        var processadorCompra = new Mock<IProcessadorCompra>();

        usuarioRepository
            .Setup(x => x.ObterAsync(It.IsAny<int>()))
            .ReturnsAsync(new Domain.Entities.Usuario());

        fornecedorService
            .Setup(x => x.GarantirExistenciaAsync(It.IsAny<FornecedorDTO>(), It.IsAny<int>()))
            .ReturnsAsync((Domain.Entities.Fornecedor)null);

        var handler = new CadastrarCompraCommandHandler(
            usuarioRepository.Object,
            estoqueRepository.Object,
            fornecedorService.Object,
            processadorCompra.Object
        );

        var command = new CadastrarCompraCommand
        {
            NumeroNotaFiscal = "",
            FornecedorInput = new FornecedorInput
            {
                CNPJ = ""
            },
            ItensComprados = new List<ItemCompraInput>
            {

            },
            UserId = 1
        };

        var resposta = await handler.Handle(command, CancellationToken.None);

        Assert.Equal((int)HttpStatusCode.BadRequest, resposta.StatusCode);
        Assert.False(resposta.Success);

        fornecedorService.Verify(
            x => x.GarantirExistenciaAsync(It.IsAny<FornecedorDTO>(), It.IsAny<int>()),
            Times.Once
        );

        processadorCompra.Verify(
            x => x.ProcessarAsync(It.IsAny<CadastrarCompraInput>(), It.IsAny<CancellationToken>()),
            Times.Never
        );
    }

    [Fact]
    public async Task Deve_retornar_created()
    {
        var usuarioRepository = new Mock<IUsuarioRepository>();
        var fornecedorService = new Mock<IFornecedorService>();
        var estoqueRepository = new Mock<IEstoqueRepository>();
        var processadorCompra = new Mock<IProcessadorCompra>();

        usuarioRepository
            .Setup(x => x.ObterAsync(It.IsAny<int>()))
            .ReturnsAsync(new Domain.Entities.Usuario());

        fornecedorService
            .Setup(x => x.GarantirExistenciaAsync(It.IsAny<FornecedorDTO>(), It.IsAny<int>()))
            .ReturnsAsync(new Domain.Entities.Fornecedor());

        estoqueRepository
            .Setup(x => x.ObterAsync(It.IsAny<int>()))
            .ReturnsAsync(new Domain.Entities.Estoque());

        var handler = new CadastrarCompraCommandHandler(
            usuarioRepository.Object,
            estoqueRepository.Object,
            fornecedorService.Object,
            processadorCompra.Object
        );

        var command = new CadastrarCompraCommand
        {
            UserId = 1,
            FornecedorInput = new FornecedorInput
            {
                CNPJ = ""
            },
            ItensComprados = new List<ItemCompraInput>()
        };

        var resposta = await handler.Handle(command, CancellationToken.None);

        Assert.Equal((int)HttpStatusCode.Created, resposta.StatusCode);
        Assert.True(resposta.Success);

        usuarioRepository.Verify(
            x => x.ObterAsync(It.IsAny<int>()),
            Times.Once
        );

        fornecedorService.Verify(
            x => x.GarantirExistenciaAsync(It.IsAny<FornecedorDTO>(), It.IsAny<int>()),
            Times.Once
        );

        estoqueRepository.Verify(
            x => x.ObterAsync(It.IsAny<int>()),
            Times.Once
        );

        processadorCompra.Verify(
            x => x.ProcessarAsync(It.IsAny<CadastrarCompraInput>(), It.IsAny<CancellationToken>()),
            Times.Once
        );
    }
}
