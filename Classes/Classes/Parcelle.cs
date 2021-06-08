using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace Classes
{
    class Parcelle
    {
        private int taille;
        private char nom;
        char[,] unite = new char[10, 10];

        public Parcelle(char n)
        {
            nom = n;
            taille = 0;

            int x, y;
            StreamReader reader;
            reader = new StreamReader(@"C:\Users\omega\Desktop\Cours\Classes\Classes\Scabb.clair.txt");
            char[,] Carte = new char[10, 10];


            for (x = 0; x < 10; x++)
            {
                for (y = 0; y < 10; y++)  /// Mise en tableau
                {
                    char line = (char)reader.Read();
                    if (line == '\n') { line = (char)reader.Read(); }
                    Carte[x, y] = line;

                    if (Carte[x, y] == nom)
                    {
                        unite[x, y] = Carte[x, y];
                    }
                }
            }
        }

        public void calculTaille(Parcelle P)
        {
            for(int x=0;x!='\n';x++)
            {
                for (int y = 0; y != '\n'; y++)
                {
                    if(unite[x,y] == nom)
                    {
                        taille = taille + 1;
                    }
                    else
                    {
                        unite[x, y] = ' ';
                    }
                }
            }

            Console.WriteLine("Taille de la parcelle {0} = {1}", nom, taille);
            Console.WriteLine();
        }

        public void Emplacement(Parcelle P)
        {
            Console.WriteLine("PARCELLE {0} - {1} unités", nom, taille);

            for (int x = 0; x != '\n'; x++)
            {
                for (int y = 0; y != '\n'; y++)
                {
                    if (unite[x, y] == nom)
                    {
                        Console.Write("({0},{1}) ", x, y);
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
