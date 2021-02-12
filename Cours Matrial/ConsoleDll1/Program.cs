using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DllCalcul;

namespace ConsoleDll1
{
    class Program
    {
        static void Main(string[] args)
        {


            string choix;
            Console.WriteLine("+. Adition");
            Console.WriteLine("-. Soustraction");
            Console.WriteLine("*. Multiplication");
            Console.WriteLine("/. Division");
            choix = Console.ReadLine();
            Console.Clear();
            float a;
            float b;
            float res;
            a = float.Parse(Console.ReadLine());
            b = float.Parse(Console.ReadLine());

            if (choix == "+")
            {
                res = Class1.add(a, b);
                Console.WriteLine(res.ToString());
                Console.ReadLine();
            }
            else if (choix == "-")
            {
                res = Class1.sub(a, b);
                Console.WriteLine(res.ToString());
                Console.ReadLine();
            } 
            else if (choix == "*")
            {
                res = Class1.mul(a, b);
                Console.WriteLine(res.ToString());
                Console.ReadLine();
            }
            else if (choix == "/")
            {
                res = Class1.div(a, b);
                Console.WriteLine(res.ToString());
                Console.ReadLine();
            }
           

            

            

            
        }
    }
}
