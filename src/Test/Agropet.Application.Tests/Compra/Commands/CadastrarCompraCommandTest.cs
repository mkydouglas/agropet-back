using Agropet.Application.Compra.Commands;
using Agropet.Application.Compra.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agropet.Application.Tests.Compra.Commands;

public class CadastrarCompraCommandTest
{
    [Fact]
    public void Deve_falhar_quando_userid_for_zero()
    {
        var validator = new CadastrarCompraCommandValidator();

        var command = new CadastrarCompraCommand
        {
            UserId = 0,
            FornecedorInput = new() { CNPJ = "" },
            ItensComprados = new()
        };

        var result = validator.Validate(command);

        Assert.False(result.IsValid, result.ToString());
    }
}
