using Agropet.Application.Compra.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agropet.Application.Compra.Validators;

public sealed class CadastrarCompraCommandValidator : AbstractValidator<CadastrarCompraCommand>
{
    public CadastrarCompraCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("UserId deve ser maior que zero.");
    }
}
