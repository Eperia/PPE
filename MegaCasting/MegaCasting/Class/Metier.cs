using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Class
{
    class Metier
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

        public Metier()
        {
            this.id = 1;
            this.nom = "test";
        }

        public DomaineMetier domaineMetier;

    }
}
