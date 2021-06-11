using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace testclasse
{
    class Ile
    {
        private string nom;
        private string adr_clair;
        private string adr_chiffre;
        char[,] carte = new char[10, 10];
        List<Parcelle> Parcelle_List;
        List<char> doublons = new List<char>();

        public Ile(string n)
        {
            nom = n;
            adr_clair = String.Format(@"..\..\..\..\{0}.clair.txt", nom);
            adr_chiffre = String.Format(@"..\..\..\..\{0}.chiffre.txt", nom);
            StreamReader reader = new StreamReader(adr_clair);

            Parcelle_List = new List<Parcelle>();

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)  /// Mise en tableau
                {
                    char line = (char)reader.Read();
                    if (line == '\n') { line = (char)reader.Read(); }
                    carte[x, y] = line;

                    Console.Write(line);
                }
                Console.WriteLine();
            }
        }

        public void Chiffre()
        {
            int x, y;
            StreamReader reader = new StreamReader(adr_clair);
            char[,] Carte = new char[10, 10];

            for (x = 0; x < 10; x++)
            {
                for (y = 0; y < 10; y++)  /// Mise en tableau
                {
                    char line = (char)reader.Read();
                    if (line == '\n') { line = (char)reader.Read(); }
                    Carte[x, y] = line;
                }

            }

            StreamWriter writer = new StreamWriter(adr_chiffre);
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

        public char[,] Carte { get => carte; set => carte = value; }

        public void createParcelle()
        {

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)  /// Mise en tableau
                {
                    char parcelle_n = carte[x, y];
                    bool b = doublons.Contains(parcelle_n);

                    if ((parcelle_n != 'M') && (parcelle_n != 'F'))
                    {
                        if (b == false)
                        {
                            Parcelle_List.Add(new Parcelle(parcelle_n));
                            doublons.Add(parcelle_n);
                        }
                    }
                }
            }
        }

        public int calculTaille()
        {
            Console.WriteLine("De quelle parcelle voulez-vous connaitre la taille ? :");
            char Parcelle_nom = Convert.ToChar(Console.ReadLine());
            bool b = !doublons.Contains(Parcelle_nom);

            foreach (Parcelle val in Parcelle_List)
            {
                if(val.Nom == Parcelle_nom)
                {
                    for (int x = 0; x != '\n'; x++)
                    {
                        for (int y = 0; y != '\n'; y++)
                        {
                            if (Carte[x, y] == val.Nom)
                            {
                                val.Taille += 1;
                            }
                        }
                    }

                    Console.WriteLine("Taille de la parcelle {0} = {1}", val.Nom, val.Taille);
                    Console.WriteLine();
                }
                else
                    if(b)
                    {
                        Console.WriteLine("Parcelle {0} - inexistante", Parcelle_nom);
                        Console.WriteLine("taille de la parcelle {0} = 0", Parcelle_nom);

                    return 0;
                    }
            }

            return 0;
        }

        public void Emplacement()
        {
            foreach (Parcelle val in Parcelle_List)
            {
                Console.WriteLine("PARCELLE {0} - {1} unités", val.Nom, val.Taille);

                for (int x = 0; x != '\n'; x++)
                {
                    for (int y = 0; y != '\n'; y++)
                    {
                        if (Carte[x, y] == val.Nom)
                        {
                            Console.Write("({0},{1}) ", x, y);
                        }
                    }
                }
                Console.WriteLine();
            }
        }


    }
}
