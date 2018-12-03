using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Class
{
    public class Metier
    {
        private Int64 id;

        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }
        private string nom;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        private Int64 id_DomaineMetier;

        public Int64 Id_DomaineMetier
        {
            get { return id_DomaineMetier; }
            set { id_DomaineMetier = value; }
        }

       

    }
}
