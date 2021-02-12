using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DllCalcul
{
    public class Class1
    {
        public static float add (float a, float b)
        {
            return a + b;
        }

        public static float sub(float a, float b)
        {
            return a - b;
        }

        public static float div(float a, float b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }
            else
            {
                return a / b;
            }
            
        }
        
        public static float mul(float a, float b)
        {
            return a * b;
        }
    }
}
