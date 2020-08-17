using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlExercise.Repository;

namespace XmlExercise
{
    public sealed class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the type of XML operation you would like to perform :" +
                "\n" + "1. Read from XML file (Enter R)" + "\n" + "2. Add node to XML file (Enter A)" +
                "\n" + "3. Delete node from XML file (Enter D)" + "\n" + "4. Write to a new XML file (Enter W)");
            string inOpertaion = Console.ReadLine();
            if (inOpertaion == "R" || inOpertaion == "A" || inOpertaion == "D")
            {
                Console.WriteLine("Enter the file path to process :");
                string filePath = Console.ReadLine();
                XmlFileOperations xmlOperation = new XmlFileOperations(filePath);
                switch (inOpertaion)
                {
                    case "R":
                        {
                            Console.WriteLine("--- Output of the file content ----");
                            Console.WriteLine(xmlOperation.ReadXml());
                            break;
                        }
                    case "A":
                        {
                            Console.WriteLine("Enter the Parent to add to : ");
                            string parent = Console.ReadLine();
                            Console.WriteLine("Enter the new element name : ");
                            string elementName = Console.ReadLine();
                            Console.WriteLine("Enter the element content (Xml or text) : ");
                            string content = Console.ReadLine();
                            Console.WriteLine("Employee name to filter : ");
                            string filterName = Console.ReadLine();
                            filterName = string.IsNullOrEmpty(filterName) ? string.Empty : filterName;
                            xmlOperation.AddNode(@"//" + parent, elementName, content, filterName);

                            // output file after update
                            Console.WriteLine("--- Output of the file content ----");
                            Console.WriteLine(xmlOperation.ReadXml());
                            Console.ReadKey();
                            break;
                        }
                    case "D":
                        {
                            Console.WriteLine("Enter the Parent to delete from : ");
                            string parent = Console.ReadLine();
                            Console.WriteLine("Enter the element name : ");
                            string elementName = Console.ReadLine();

                            xmlOperation.DeleteNode(@"//" + parent, elementName);

                            // output file after update
                            Console.WriteLine("--- Output of the file content ----");
                            Console.WriteLine(xmlOperation.ReadXml());
                            break;
                        }
                    default: break;
                }

            }
            else if (inOpertaion == "W")
            {
                Console.WriteLine("Enter the file name to create : ");
                string filePath = Console.ReadLine();
                XmlFileOperations xmlWrite = new XmlFileOperations(filePath);
                Console.WriteLine("Enter the XML content to write in file : ");
                string content = Console.ReadLine();

                xmlWrite.WriteToXml(filePath, content);

                // output file after update
                Console.WriteLine("--- Output of the file content ----");
                Console.WriteLine(xmlWrite.ReadXml());
            }
            else
            {
                Console.WriteLine("Not a valid input.");
            }
            Console.WriteLine("Press any key to exit!!!");
            Console.ReadKey();
        }
    }
}
