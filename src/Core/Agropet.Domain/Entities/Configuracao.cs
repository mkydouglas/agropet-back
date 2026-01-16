using Agropet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agropet.Domain.Entities;

public class Configuracao : BaseEntity
{
    public Configuracao(ENomeConfiguracao nome, string valor)
    {
        Nome = nome;
        Valor = valor;
    }

    public ENomeConfiguracao Nome { get; private set; }
    public string Valor { get; private set; } = string.Empty;

    public double ObterValor()
    {
        var valor = double.TryParse(Valor, out double result);
        return valor ? result : 0d;
    }

    public Configuracao AtualizarValor(string valor)
    {
        Valor = valor;
        return this;
    }
}
