using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Rhum
{
    class Parcelle
    {
        private int taille;
        private char nom;

        public Parcelle(char n)
        {
            nom = n;
            taille = 0;
        }

        public char Nom { get => nom; set => nom = value; }
        public int Taille { get => taille; set => taille = value; }
    }
}
