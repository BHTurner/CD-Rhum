using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace Classes
{
    class Ile
    {
        #region Attributs
        private string nom;
        private string adr_clair;
        private string adr_chiffre;
        List<Parcelle> Parcelle_Liste;
        #endregion 

        #region Constructeur
        public Ile(string n)
        {
            nom = n;
            adr_clair = String.Format(@"..\..\..\..\{0}.clair.txt", nom);
            adr_chiffre = String.Format(@"..\..\..\..\{0}.chiffre.txt", nom);
        }
        #endregion

        #region Méthodes
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
        #endregion
    }
}
