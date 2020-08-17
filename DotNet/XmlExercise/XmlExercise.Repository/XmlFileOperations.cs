using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlExercise.Interface;

namespace XmlExercise.Repository
{
    public class XmlFileOperations : IXmlFileOperation
    {
        private static string FilePath = string.Empty;
        private static XmlDocument XmlFile = new XmlDocument();

        public XmlFileOperations(string fileLocation)
        {
            FilePath = fileLocation;
        }

        private static void LoadXmlDocument()
        {
            XmlFileOperations fileObj = new XmlFileOperations(FilePath);
            XmlFile.LoadXml(fileObj.ReadXml());
        }

        public void AddNode(string parentNode, string addedNode, string content, string filter = "")
        {
            //Load
            LoadXmlDocument();

            //Add
            //XmlElement newElem = XmlFile.CreateElement(addedNode);
            //newElem.InnerXml = content;
            XmlNode newElem = XmlFile.CreateElement(addedNode);
            newElem.InnerXml = content;

            //Save
            foreach (XmlNode item in XmlFile.SelectNodes(parentNode))
            {
                if (item?.FirstChild?.InnerText == filter)
                {
                    XmlNodeList existsNode = item.SelectNodes(addedNode);
                    if (existsNode != null) { foreach (XmlNode x in existsNode) { item.RemoveChild(x); } }
                    item.InsertAfter(newElem, item.LastChild);
                    break;
                }
                else if (string.IsNullOrEmpty(filter)) { item.InsertAfter(newElem, item.LastChild); }
            }
            XmlFile.Save(FilePath);
        }

        public void DeleteNode(string parentNode, string deleteNode)
        {
            //Load
            LoadXmlDocument();

            //Remove            
            foreach (XmlNode item in XmlFile.SelectNodes(parentNode))
            {
                XmlNodeList existsNode = item.SelectNodes(deleteNode);
                if (existsNode != null) { foreach (XmlNode x in existsNode) { item.RemoveChild(x); } }
            }
            //Save
            XmlFile.Save(FilePath);
        }

        public string ReadXml()
        {
            return System.IO.File.ReadAllText(FilePath);
        }

        public void WriteToXml(string writePath, string content)
        {
            //Create
            XmlDocument doc = new XmlDocument();                       
            doc.LoadXml(content);

            //Save
            doc.Save(writePath);
        }
    }
}
