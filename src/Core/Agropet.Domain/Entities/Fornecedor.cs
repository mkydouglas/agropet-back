namespace Agropet.Domain.Entities;

public class Fornecedor : BaseEntity
{
    public string? CNPJ { get; private set; }
    public string? RazaoSocial { get; private set; }
    public string? NomeFantasia { get; private set; }
    public string? Telefone { get; private set; }

    public void Atualizar(string? cnpj, string? razaoSocial, string? nomeFantasia, string? telefone)
    {
        CNPJ = cnpj;
        RazaoSocial = razaoSocial;
        NomeFantasia = nomeFantasia;
        Telefone = telefone;
    }

    #region Relacionamento

    public ICollection<FornecedorLote>? FornecedorLote { get; set; }

    #endregion
}
