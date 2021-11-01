using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1Test.Metier
{
    public class Calcul
    {
        public int Addition(int a, int b)
        {
            //return a + b; 
            for (int i = 0; i < a; i++)
            {
                b = b + 1;
            }
            return b;

        }
    }
}
