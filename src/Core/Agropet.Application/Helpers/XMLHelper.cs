using Agropet.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Agropet.Application.Helpers;

public static class XMLHelper
{
    public static NfeProc? LerNF(Stream stream)
    {
        NfeProc? nota = null;

        using (XmlReader reader = XmlReader.Create(stream))
        {
            reader.MoveToContent(); // Move para o nó raiz

            string namespaceXml = reader.NamespaceURI; // Captura o namespace dinamicamente

            // Criar serializer com o namespace correto
            XmlSerializer serializer = new XmlSerializer(typeof(NfeProc), namespaceXml);

            using (reader)
            {
                nota = (NfeProc)serializer.Deserialize(reader);
            }
        }

        return nota;
    }
}
