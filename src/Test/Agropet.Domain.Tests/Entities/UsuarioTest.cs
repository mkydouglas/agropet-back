using Agropet.Domain.Entities;

namespace Agropet.Domain.Tests.Entities;

public class UsuarioTest
{
    [Fact]
    public void Deve_atualizar_o_nome()
    {
        var usuario = new Usuario();
        usuario.AtualizarNome("teste");

        Assert.Equal("teste", usuario.Nome);
    }

    [Fact]
    public void Nao_deve_alterar_quando_nome_for_vazio()
    {
        var usuario = new Usuario();
        usuario.AtualizarNome("teste");
        usuario.AtualizarNome("");

        Assert.Equal("teste", usuario.Nome);
    }

    [Fact]
    public void Deve_atualizar_o_cpf()
    {
        var usuario = new Usuario();
        usuario.AtualizarCPF("22222222222");

        Assert.Equal("22222222222", usuario.CPF);
    }

    [Fact]
    public void Nao_deve_alterar_quando_cpf_for_vazio()
    {
        var usuario = new Usuario();
        usuario.AtualizarCPF("11111111111");
        usuario.AtualizarCPF("");

        Assert.Equal("11111111111", usuario.CPF);
    }

    [Fact]
    public void Nao_deve_alterar_quando_cpf_invalido()
    {
        var usuario = new Usuario();
        usuario.AtualizarCPF("11111111111");
        usuario.AtualizarCPF("asge 1111");

        Assert.Equal("11111111111", usuario.CPF);
    }
}
