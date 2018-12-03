using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Class
{
    public class Pack
    {

        private Int64 id;

        public Int64 ID
        {
            get { return id; }
            set { id = value; }
        }

        private string libelle;

        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }

        private PrixPack prixPack;

        public PrixPack PrixPack
        {
            get { return prixPack; }
            set { prixPack = value; }
        }

        private int nbrPoste;

        public int NbrPoste
        {
            get { return nbrPoste; }
            set { nbrPoste = value; }
        }

        public Pack() {
            PrixPack = new PrixPack();

        }


    }
}
