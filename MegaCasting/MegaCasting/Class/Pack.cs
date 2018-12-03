using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Class
{
    public class Pack
    {
        #region Champs
        private Int64 id;
        private string libelle;
        private PrixPack prixPack;
        private int nbrPoste;

        #endregion

        #region Propriétés
        public Int64 ID
        {
            get { return id; }
            set { id = value; }
        }


        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }


        public PrixPack PrixPack
        {
            get { return prixPack; }
            set { prixPack = value; }
        }


        public int NbrPoste
        {
            get { return nbrPoste; }
            set { nbrPoste = value; }
        }

        public Pack()
        {
            PrixPack = new PrixPack();

        }
        #endregion



    }
}
