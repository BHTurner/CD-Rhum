using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Rhum
{
    class Ile
    {
        #region Attributs
        /// <summary>
        /// Nom de la carte
        /// </summary>
        private string nom;

        /// <summary>
        /// Adresse de la carte clair
        /// </summary>
        private string adr_clair;

        /// <summary>
        /// Adresse de la carte chiffrée
        /// </summary>
        private string adr_chiffre;

        /// <summary>
        /// Adresse de la carte dechiffrée par le programme
        /// </summary>
        private string adr_dechiffre;

        /// <summary>
        /// Variable égale au nombre de parcelle d'une carte
        /// </summary>
        private static int nbParcelle = 0;
        #endregion

        #region tableaux
        /// <summary>
        /// Tableau deux dimensions qui va prendre les valeurs de la carte
        /// </summary>
        char[,] carte = new char[10, 10];

        /// <summary>
        /// Tableau de la carte déchiffrée
        /// </summary>
        char[,] carteDechifr = new char[10, 10];
        #endregion

        #region Listes
        /// <summary>
        /// Liste contenant la liste des parcelles d'une carte
        /// </summary>
        List<Parcelle> Parcelle_List = new List<Parcelle>();

        /// <summary>
        /// Liste permetttant d'éviter les doublons de la liste 'Parcelle_list'
        /// </summary>
        List<char> doublons = new List<char>();
        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur permettant de transmettre la carte ayant copier les données de la carte .clair
        /// </summary>
        public char[,] Carte { get => carte; set => carte = value; }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur permettant de modéliser un objet "ile"
        /// </summary>
        public Ile(string n)
        {
            nom = n;
            adr_clair = String.Format(@"..\..\..\Cartes\{0}.clair", nom);
            adr_chiffre = String.Format(@"..\..\..\Cartes\{0}.chiffre", nom);
            adr_dechiffre = String.Format(@"..\..\..\Cartes\{0}2.clair", nom);
            StreamReader readerClair = new StreamReader(adr_clair);

            Console.WriteLine("Voulez-vous partir d'une carte .clair ou .chiffre ?");
            string reponse = Convert.ToString(Console.ReadLine());

            if(reponse == ".clair" || reponse == ".Clair" || reponse == "clair" || reponse == "Clair")
            {
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)  /// Mise en tableau
                    {
                        char line = (char)readerClair.Read();
                        if (line == '\n' || line == '\r')
                        {
                            line = (char)readerClair.Read();
                        }
                        carte[x, y] = line;
                    }
                }

                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        char parcelle_n = carte[x, y];
                        bool b = doublons.Contains(parcelle_n);

                        if ((parcelle_n != 'M') && (parcelle_n != 'F'))
                        {
                            if (b == false)
                            {
                                Parcelle_List.Add(new Parcelle(parcelle_n));
                                doublons.Add(parcelle_n);
                                nbParcelle += 1;
                            }
                        }
                    }
                }
            }
            else
                if(reponse == ".chiffre" || reponse == ".Chiffre" || reponse == "chiffre" || reponse == "Chiffre")
                {
                    dechiffre();
                }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Methode permettant de déchiffrer une carte .chiffre
        /// </summary>
        public void dechiffre()
        {
            using (StreamReader reader = new StreamReader(adr_chiffre))
            {
                int x, i, y, nb = 0, idxLigne, codeAsc = 97;
                string fichier;
                string[] tab1 = new string[10];
                string[] tab2 = new string[10];
                int[,] tab3 = new int[10, 10];
                int[,] tab4 = new int[10, 10];
                bool mer = false, foret = false, frtO = false, frtE = false, frtN = false, frtS = false;

                fichier = reader.ReadLine();
                tab1 = fichier.Split("|");

                for (i = 0; i < 10; i++)      //Formation du tableau
                {
                    tab2 = tab1[i].Split(":");
                    for (idxLigne = 0; idxLigne < 10; idxLigne++)
                    {
                        tab3[i, idxLigne] = Convert.ToInt32(tab2[idxLigne]);

                    }
                }

                StreamWriter writer = new StreamWriter(adr_dechiffre);//Création du .txt déchiffré
                using (writer)
                {
                    for (x = 0; x < 10; x++)
                    {

                        for (y = 0; y < 10; y++)
                        {
                            if (tab3[x, y] >= 64)                 //Si c'est la Mer
                            {
                                tab4[x, y] = 77;
                                tab3[x, y] = tab3[x, y] - 64;
                                mer = true;
                            }
                            if (tab3[x, y] >= 32 && !mer)         //Si c'est la Foret
                            {
                                tab4[x, y] = 70;
                                tab3[x, y] = tab3[x, y] - 32;
                                foret = true;
                            }

                            if (tab3[x, y] >= 8)                  //Si pas de frontière à l'est
                            {
                                tab3[x, y] = tab3[x, y] - 8;
                                frtE = true;
                            }
                            if (tab3[x, y] >= 4)                  //Si pas de frontière au sud
                            {
                                tab3[x, y] = tab3[x, y] - 4;
                                frtS = true;
                            }
                            if (tab3[x, y] >= 2)                  //Si pas de frontière à l'ouest
                            {
                                tab3[x, y] = tab3[x, y] - 2;
                                frtO = true;
                            }
                            if (tab3[x, y] >= 1)                  //Si pas de frontière au nord
                            {
                                tab3[x, y] = tab3[x, y] - 1;
                                frtN = true;
                            }

                            if (!frtO && !mer && !foret)
                            {
                                tab4[x, y] = tab4[x, y - 1];
                            }
                            if (!frtN && !mer && !foret)
                            {
                                tab4[x, y] = tab4[x - 1, y];
                            }

                            if (frtN && frtO && !mer && !foret && nb != 0)
                            {
                                codeAsc++;
                                tab4[x, y] = codeAsc;
                            }
                            if (frtN && frtO && !mer && !foret)
                            {
                                nb++;
                                tab4[x, y] = codeAsc;
                            }
                            mer = false;
                            foret = false;
                            frtO = false;
                            frtE = false;
                            frtN = false;
                            frtS = false;
                        }
                    }

                    for (x = 0; x < 10; x++)          //Affichage du tableau final
                    {
                        for (y = 0; y < 10; y++)
                        {
                            writer.Write("{0}", Convert.ToChar(tab4[x, y]));
                            carteDechifr[x, y] = Convert.ToChar(tab4[x, y]);
                        }
                        writer.WriteLine();
                    }
                }
            }
        }

        /// <summary>
        /// Methode permettant de chiffrer une carte
        /// </summary>
        public void Chiffre()
        {
            int x, y;

            StreamWriter writer = new StreamWriter(adr_chiffre);
            double Valeur;
            Valeur = 0;
            
            using (writer)
            {
                for (x = 0; x < 10; x++)
                {
                    for (y = 0; y < 10; y++)  /// Codage
                    {
                        if (x - 1 < 0 || carte[x, y] != carte[x - 1, y])
                        {
                            Valeur += Math.Pow(2, 0);
                        }
                        if (x + 1 > 9 || carte[x, y] != carte[x + 1, y])
                        {
                            Valeur += Math.Pow(2, 2);
                        }
                        if (y - 1 < 0 || carte[x, y] != carte[x, y - 1])
                        {
                            Valeur += Math.Pow(2, 1);
                        }
                        if (y + 1 > 9 || carte[x, y] != carte[x, y + 1])
                        {
                            Valeur += Math.Pow(2, 3);
                        }
                        if (carte[x, y] == 'M')
                        {
                            Valeur += Math.Pow(2, 6);
                        }
                        if (carte[x, y] == 'F')
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

        /// <summary>
        /// Methode permettant de calculter la taille d'une parcelle
        /// </summary>
        public int CalculTaille(char Parcelle_n)
        {
            bool b = !doublons.Contains(Parcelle_n);
            int ParcelleTaille = 0;

            foreach (Parcelle P in Parcelle_List)
            {
                if (P.Nom == Parcelle_n)
                {
                    for (int x = 0; x != '\n'; x++)
                    {
                        for (int y = 0; y != '\n'; y++)
                        {
                            if (carte[x, y] == P.Nom)
                            {
                                P.Taille += 1;
                            }
                        }
                    }

                    ParcelleTaille = P.Taille;

                }
                else
                    if (b)
                {
                    Console.WriteLine("Parcelle {0} - inexistante", Parcelle_n);
                    Console.WriteLine("taille de la parcelle {0} = 0", Parcelle_n);

                    return 0;
                }
            }

            return ParcelleTaille;
        }

        /// <summary>
        /// Methode permettant de donner l'emplacement de chaque unité en fonction de sa parcelle
        /// </summary>
        public void Emplacement()
        {
            foreach (Parcelle P in Parcelle_List)
            {
                Console.WriteLine("PARCELLE {0} - {1} unités", P.Nom, P.Taille);

                for (int x = 0; x != '\n'; x++)
                {
                    for (int y = 0; y != '\n'; y++)
                    {
                        if (carte[x, y] == P.Nom)
                        {
                            Console.Write("({0},{1}) ", x, y);
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Methode permettant de calculer la taille moyenne des parcelles présentes dans l'objet "ile"
        /// </summary>
        public void MoyenneTaille()
        {
            double moyenne = 0;
            foreach (Parcelle P in Parcelle_List)
            {
                moyenne += CalculTaille(P.Nom);
            }
            Console.WriteLine("Moyenne: {0}", Math.Round(moyenne / nbParcelle, 2));
        }

        /// <summary>
        /// Methode permettant d'afficher les parcelles présentent dans la liste si leur taille est supérieure à une variable choisie par l'utilisateur
        /// </summary>
        public void TailleSuperieur()
        {
            int nb, x = 0;
            Console.Write("Parcelle(s) de taille supérieur à : ");
            Console.WriteLine();
            nb = Convert.ToInt32(Console.ReadLine());
            foreach (Parcelle P in Parcelle_List)
            {
                if (P.Taille >= nb)
                {
                    Console.WriteLine("Parcelle {0} : {1} unités", P.Nom, P.Taille);
                    x++;
                }
            }
            if (x == 0)
            {
                Console.WriteLine("Aucune parcelle");
            }
        }

        /// <summary>
        /// Methode permettant d'afficher la carte une fois déchiffrée
        /// </summary>
        public void Affichage()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)  /// Mise en tableau
                {
                    char var = carteDechifr[x, y];
                    if (var == 'M')
                    {
                        Console.ForegroundColor = System.ConsoleColor.Blue;
                        Console.Write("{0} ", var);
                        Console.ResetColor();
                    }
                    else if (var == 'F')
                    {
                        Console.ForegroundColor = System.ConsoleColor.Green;
                        Console.Write("{0} ", var);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0} ", var);
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
        }
        #endregion
    }
}
