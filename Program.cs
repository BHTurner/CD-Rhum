using System;
using System.Threading;

namespace Rhum
{/// <summary> Programme Principal </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            bool exit = true;
            int Choix = 0;
            Ile Scabb = new Ile("Scabb");
            Ile Phatt = new Ile("Phatt");

            Console.WriteLine("Choisir une carte:");
            Console.WriteLine("[1] Scabb");
            Console.WriteLine("[2] Phatt");
            do
            {
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                } catch (Exception)
                {
                    Console.WriteLine("N'utilisez que des chiffres");
                    return;
                }

                switch (option)  ///Choix de la carte
                {
                    case 1:
                        Console.WriteLine("Chiffrage de la carte {0} ...", Scabb.Nom);
                        Scabb.Chiffre();
                        Thread.Sleep(100);
                        Console.WriteLine("Déchiffrage de la carte {0} ...", Scabb.Nom);
                        Scabb.Dechiffre();
                        Thread.Sleep(100);
                        Console.WriteLine("Terminé.");
                        Choix = 1;
                        break;
                    case 2:
                        Console.WriteLine("Chiffrage de la carte {0} ...", Phatt.Nom);
                        Phatt.Chiffre();
                        Thread.Sleep(100);
                        Console.WriteLine("Déchiffrage de la carte {0} ...", Phatt.Nom);
                        Phatt.Dechiffre();
                        Thread.Sleep(100);
                        Console.WriteLine("Terminé.");
                        Choix = 2;
                        break;
                    default:
                        Console.WriteLine("Réessayez");
                        Console.WriteLine();
                        break;
                }
            } while (option != 1 && option != 2);

            while (exit)
            {
                Console.WriteLine();
                Console.WriteLine("[1] Afficher la carte");
                Console.WriteLine("[2] Affichage des parcelles");
                Console.WriteLine("[3] Affichage de la taille moyenne des parcelles");
                Console.WriteLine("[4] Affichage des parcelles supérieur à un nombre");
                Console.WriteLine("[5] Quitter");
                Console.Write("Quel option vous prenez : ");
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("N'utilisez que des chiffres");
                    return;
                }

                switch (option)  ///Choix des méthodes proposées
                {
                    case 1:
                        Console.WriteLine();
                        if (Choix == 1) { Scabb.Affichage(); }
                        if (Choix == 2) { Phatt.Affichage(); }
                        break;

                    case 2:
                        Console.WriteLine();
                        if (Choix == 1) { Scabb.Emplacement(); }
                        if (Choix == 2) { Phatt.Emplacement(); }
                        break;

                    case 3:
                        Console.WriteLine();
                        if (Choix == 1) { Scabb.MoyenneTaille(); }
                        if (Choix == 2) { Phatt.MoyenneTaille(); }
                        break;

                    case 4:
                        Console.WriteLine();
                        if (Choix == 1) { Scabb.TailleSuperieur(); }
                        if (Choix == 2) { Phatt.TailleSuperieur(); }
                        break;

                    default:
                        Console.WriteLine("Exit");
                        exit = false;
                        break;
                }
            }
            Environment.Exit(0);
        }
    }
}
