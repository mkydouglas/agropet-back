using System.Xml.Serialization;

namespace Agropet.Domain.Models
{
    [XmlRoot(ElementName = "nfeProc")]
    public class NfeProc
    {

        [XmlElement(ElementName = "NFe")]
        public NFe NFe { get; set; }
    }

    [XmlRoot(ElementName = "NFe")]
    public class NFe
    {
        [XmlElement(ElementName = "infNFe")]
        public InfNFe InfNFe { get; set; }
    }

    [XmlRoot(ElementName = "infNFe")]
    public class InfNFe
    {
        //[XmlElement(ElementName = "ide")]
        //public object Ide { get; set; }

        [XmlElement(ElementName = "emit")]
        public Emitente Emitente { get; set; }

        [XmlElement(ElementName = "det")]
        public List<InfoProduto> InfoProduto { get; set; }

        //[XmlElement(ElementName = "total")]
        //public Total Total { get; set; }
    }

    [XmlRoot(ElementName = "emit")]
    public class Emitente
    {
        [XmlElement(ElementName = "CNPJ")]
        public string CNPJ { get; set; }

        [XmlElement(ElementName = "xNome")]
        public string RazaoSocial { get; set; }

        [XmlElement(ElementName = "xFant")]
        public string NomeFantasia { get; set; }

        [XmlElement(ElementName = "enderEmit")]
        public EnderEmit EnderEmit { get; set; }

        [XmlElement(ElementName = "IE")]
        public double IE { get; set; }

        [XmlElement(ElementName = "CRT")]
        public int CRT { get; set; }
    }

    [XmlRoot(ElementName = "enderEmit")]
    public class EnderEmit
    {
        [XmlElement(ElementName = "fone")]
        public string Fone { get; set; }
    }

    [XmlRoot(ElementName = "det")]
    public class InfoProduto
    {

        [XmlElement(ElementName = "prod")]
        public Prod Produto { get; set; }

        [XmlElement(ElementName = "imposto")]
        public object Imposto { get; set; }

        [XmlElement(ElementName = "infAdProd")]
        public string InfAdProd { get; set; }

        [XmlAttribute(AttributeName = "nItem")]
        public int NItem { get; set; }
    }

    public class Prod
    {

        [XmlElement(ElementName = "cProd")]
        public int Codigo { get; set; }

        [XmlElement(ElementName = "cEAN")]
        public long CodigoBarras { get; set; }

        [XmlElement(ElementName = "xProd")]
        public string Nome { get; set; }

        [XmlElement(ElementName = "NCM")] //Nomenclatura Comum do Mercosul
        public int NCM { get; set; }

        [XmlElement(ElementName = "CEST")] //Código Especificador da Substituição Tributária
        public int CEST { get; set; }

        [XmlElement(ElementName = "cBenef")] //Código de Benefício Fiscal
        public object CBenef { get; set; }

        [XmlElement(ElementName = "CFOP")] //Código Fiscal de Operações e Prestações
        public int CFOP { get; set; }

        [XmlElement(ElementName = "uCom")]
        public string UnidadeComercial { get; set; }

        [XmlElement(ElementName = "qCom")]
        public string QuantidadeComercial { get; set; }

        [XmlElement(ElementName = "vUnCom")]
        public decimal ValorUnidadeComercial { get; set; }

        [XmlElement(ElementName = "vProd")]
        public decimal ValorTotal { get; set; }

        [XmlElement(ElementName = "cEANTrib")]
        public double CodigoBarrasTributavel { get; set; }

        [XmlElement(ElementName = "uTrib")]
        public string UnidadeTributavel { get; set; }

        [XmlElement(ElementName = "qTrib")]
        public string QuantidadeTributavel { get; set; }

        [XmlElement(ElementName = "vUnTrib")]
        public decimal ValorUnidadeTributavel { get; set; }

        [XmlElement(ElementName = "indTot")]
        public int IndTot { get; set; }

        [XmlElement(ElementName = "xPed")]
        public int NumeroPedidoCompra { get; set; }

        [XmlElement(ElementName = "nItemPed")]
        public int NItemPed { get; set; }

        [XmlElement(ElementName = "rastro")]
        public Rastro Rastro { get; set; }
    }

    public class Rastro
    {

        [XmlElement(ElementName = "nLote")]
        public string NLote { get; set; }

        [XmlElement(ElementName = "qLote")]
        public double QLote { get; set; }

        [XmlElement(ElementName = "dFab")]
        public DateTime DFab { get; set; }

        [XmlElement(ElementName = "dVal")]
        public DateTime DVal { get; set; }
    }
}