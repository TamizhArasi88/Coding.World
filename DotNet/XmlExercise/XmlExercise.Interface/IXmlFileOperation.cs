using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XmlExercise.Interface
{
    public interface IXmlFileOperation
    {
        string ReadXml();
        void WriteToXml(string writePath, string content);
        void AddNode(string parentNode, string addedNode, string content, string filter = "");
        void DeleteNode(string parentNode, string deleteNode);
    }
}
