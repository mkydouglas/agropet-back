namespace Agropet.Domain.Entities;

public class Fornecedor : BaseEntity
{
    public string? CNPJ { get; set; }
    public string? RazaoSocial { get; set; }
    public string? NomeFantasia { get; set; }
    public string? Telefone { get; set; }

    #region Relacionamento

    public ICollection<Lote>? Lotes { get; set; }

    #endregion
}
