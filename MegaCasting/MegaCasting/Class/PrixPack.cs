
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MegaCasting.Class
{
    public class PrixPack
    {

        private Int64 id;

        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }
        private double prix;

        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }
        private DateTime dt_Debut;

        public DateTime Dt_Debut
        {
            get { return dt_Debut; }
            set { dt_Debut = value; }
        }
        private DateTime? dt_Fin;

        public DateTime? Dt_Fin
        {
            get { return dt_Fin; }
            set { dt_Fin = value; }
        }


    }
}