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
}
