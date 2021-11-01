using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryNetFramework
{
    public class Calcul
    {

        public int Soustraction(int a, int b)
        {
            //return a + b; 
            for (int i = 0; i < a; i++)
            {
                b = b - 1;
            }
            return b;
        }
    }
}

