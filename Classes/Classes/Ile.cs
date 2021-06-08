using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class Ile
    {
        #region Attributs
        private string nom;
        List<Parcelle> Parcelle_Liste;
        #endregion 

        #region Constructeur
        public Ile(string n)
        {
            nom = n;
            string adr_clair = String.Format(@"..\..\..\..\{0}.clair.txt", nom);
            string adr_chiffre = String.Format(@"..\..\..\..\{0}.chiffre.txt", nom);
        }
        #endregion 
    }
}
