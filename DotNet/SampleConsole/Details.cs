using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SampleConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Name:");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Enter Company Name:");
                var company = Console.ReadLine();
                if (!string.IsNullOrEmpty(company))
                {
                    Console.WriteLine("Enter ID:");
                    var id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Rating:");
                    var rating = Convert.ToDouble(Console.ReadLine());

                    //-- Output
                    Console.WriteLine("User Details :");
                    Console.WriteLine("Name : " + name);
                    Console.WriteLine("Company Name :" + company);
                    Console.WriteLine("ID :" + id);
                    Console.WriteLine("Rating :" + rating);

                    Console.ReadKey();
                }
            }
        }
    }
}
