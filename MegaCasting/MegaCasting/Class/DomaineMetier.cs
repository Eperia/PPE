using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.Class
{


    public class DomaineMetier
    {
        #region champs
        private Int64 id;
        private string nom;
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
        #endregion
    }
}
