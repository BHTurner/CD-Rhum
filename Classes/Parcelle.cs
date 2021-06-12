using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Rhum
{
    class Parcelle
    {

        #region Attribut
        /// <summary>
        /// Nom de Parcelle
        /// </summary>
        private char nom;

        /// <summary>
        /// Taille de la parcelle
        /// </summary>
        private int taille;
        #endregion

        #region Accesseurs

        /// <summary>
        /// Accesseur permettant de transmettre la veleur du nom de la parcelle
        /// </summary>
        public char Nom { get => nom; set => nom = value; }

        /// <summary>
        /// Accesseur permettant de transmettre la veleur de la taille de la parcelle
        /// </summary>
        public int Taille { get => taille; set => taille = value; }
        #endregion

        #region Constructeurs

        /// <summary>
        /// Constructeur permetant de modéliser un objet "Parcelle"
        /// </summary>
        public Parcelle(char n)
        {
            nom = n;
            taille = 0;
        }
        #endregion
    }
}
