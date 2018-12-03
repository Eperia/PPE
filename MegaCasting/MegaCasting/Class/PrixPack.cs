
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MegaCasting.Class
{


    public class PrixPack
    {
        #region Champs
        private Int64 id;
        private double prix;
        private DateTime dt_Debut;
        private DateTime? dt_Fin;

        #endregion

        #region Propriétés
        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        public DateTime Dt_Debut
        {
            get { return dt_Debut; }
            set { dt_Debut = value; }
        }

        public DateTime? Dt_Fin
        {
            get { return dt_Fin; }
            set { dt_Fin = value; }
        }
        #endregion




    }
}