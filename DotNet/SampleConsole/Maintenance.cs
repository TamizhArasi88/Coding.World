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
            Console.WriteLine("Enter the maintenance cost of all the 3 assets");
            int counter = 0;
            double total = 0.00;
            for (int i = 0; i < 3; i++)
            {
                total = total + Convert.ToDouble(Console.ReadLine());
                counter++;
            }
            Console.WriteLine("Total maintenance cost:" + total);
            Console.ReadKey();
        }       

    }
}
