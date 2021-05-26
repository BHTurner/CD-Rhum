using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Projet
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int x, y, i;
            string ligneFichier;

            StreamReader reader;
            reader = new StreamReader(@"C:\Users\paolo\OneDrive\Bureau\Cours\DUT info 1\S2\Conc Objet\Projet\Scabb.chiffre.txt");
            string[] tab1 = new string[10];
            string[][] tab2 = new string[10][];




            tab1 = reader.Split('|');

            for (i = 0; i < 3; i++)
            {
                tab2[i] = tab1[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            }


            for (x = 0; x < 10; x++)
            {
                for (y = 0; y < 10; y++)
                {
                    Console.Write(tab2[x]);
                }
            }



        }




    }
}
