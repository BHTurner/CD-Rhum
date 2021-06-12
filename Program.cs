using System;

namespace Rhum
{
    class Program
    {
        static void Main(string[] args)
        {
            Ile Scabb = new Ile("Scabb");
            Scabb.createParcelle();
            Scabb.MoyenneTaille();
            Scabb.Emplacement();
            Scabb.Affichage();
        }
    }
}
