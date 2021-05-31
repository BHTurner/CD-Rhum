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
            string adr = String.Format(@"..\..\..\..\{0}.clair.txt", nom);
        }
        #endregion 
    }
}
