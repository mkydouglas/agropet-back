namespace Agropet.Application.Usuario.Responses;

public sealed record UsuarioResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
}
