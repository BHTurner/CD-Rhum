using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Parcelle P = new Parcelle('a');

            P.calculTaille(P);
            P.Emplacement(P);
        }
    }
}
