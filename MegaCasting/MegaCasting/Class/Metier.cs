using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Class
{
    public class Metier
    {
        #region Champs
        private Int64 id;
        private string nom;
        private Int64 id_DomaineMetier;
        #endregion

        #region propriétés


        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }


        public Int64 Id_DomaineMetier
        {
            get { return id_DomaineMetier; }
            set { id_DomaineMetier = value; }
        }
        #endregion


    }
}
