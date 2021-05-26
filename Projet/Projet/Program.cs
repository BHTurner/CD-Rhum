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
            int x, y;
            StreamReader reader;
            reader = new StreamReader(@"..\..\..\..\Scabb.clair.txt");
            char[,] Carte = new char[10, 10];

            for  (x = 0; x <10; x++)
            {
                for (y = 0; y <10; y++)  /// Mise en tableau
                {
                   char line = (char)reader.Read();
                   if (line == '\n') { line = (char)reader.Read(); }
                   Carte[x, y] = line;
                }

            }
            for (x = 0; x < 10; x++)
            {
                for (y = 0; y < 10; y++)  /// Affichage tableau
                {
                    Console.Write(Carte[x, y]);
                }
                Console.WriteLine();
            }

            StreamWriter writer = new StreamWriter(@"..\..\..\..\Scabb.chiffre.txt");
            double Valeur;
            Valeur = 0;

            using (writer)
            {
                for (x = 0; x < 10; x++)
                {
                    for (y = 0; y < 10; y++)  /// Codage
                    {
                        if (x - 1 < 0 || Carte[x, y] != Carte[x - 1, y])
                        {
                            Valeur += Math.Pow(2, 0);
                        }
                        if (x + 1 > 9 || Carte[x, y] != Carte[x + 1, y])
                        {
                            Valeur += Math.Pow(2, 2);
                        }
                        if (y - 1 < 0 || Carte[x, y] != Carte[x, y - 1])
                        {
                            Valeur += Math.Pow(2, 1);
                        }
                        if (y + 1 > 9 || Carte[x, y] != Carte[x, y + 1])
                        {
                            Valeur += Math.Pow(2, 3);
                        }
                        if (Carte[x, y] == 'M')
                        {
                            Valeur += Math.Pow(2, 6);
                        }
                        if (Carte[x, y] == 'F')
                        {
                            Valeur += Math.Pow(2, 5);
                        }
                        if (y != 9)
                        {
                            writer.Write("{0}:", Valeur);
                        }
                        else
                        {
                            writer.Write("{0}", Valeur);
                        }
                        Valeur = 0;
                    }
                    writer.Write("|");

                }

            }
        }
    }
}
