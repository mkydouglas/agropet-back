using Agropet.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.Xml.Serialization;

namespace Agropet.API
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class TesteNFController : ControllerBase
    //{
    //    [HttpGet]
    //    public IActionResult Get()
    //    {
    //        string caminhoXml = @"C:\Users\m.rosa.AVTCORP\Downloads\nfe-erro.xml";

    //        using (XmlReader reader = XmlReader.Create(caminhoXml))
    //        {
    //            reader.MoveToContent(); // Move para o nó raiz

    //            string namespaceXml = reader.NamespaceURI; // Captura o namespace dinamicamente

    //            Console.WriteLine($"Namespace detectado: {namespaceXml}");

    //            // Criar serializer com o namespace correto
    //            XmlSerializer serializer = new XmlSerializer(typeof(NfeProc), namespaceXml);

    //            using (StreamReader sr = new StreamReader(caminhoXml))
    //            {
    //                NfeProc nota = (NfeProc)serializer.Deserialize(sr);
    //                Console.WriteLine(nota); // Exemplo de uso
    //            }
    //        }

    //        return Ok();
    //    }
    //}
}
