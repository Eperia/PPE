using System;

namespace MegaCasting.repository
{
    public class Professionnel
    {

        #region Champs
        private Int64 id;
        private string libelle;
        private string url;
        private string telephone;
        private string email;
        private int nbrPoste;
        private string fax;
        private string mdp;
        private string rue;
        private string ville;
        private string pays;
        private string codePostal;

        #endregion
        #region Propriété
        public Int64 Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Libelle
        {
            get { return libelle; }
            set { libelle = value; }
        }


        public string URL
        {
            get { return url; }
            set { url = value; }
        }


        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }


        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int NbrPoste
        {
            get { return nbrPoste; }
            set { nbrPoste = value; }
        }


        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }


        public string Mdp
        {
            get { return mdp; }
            set { mdp = value; }
        }


        public string Rue
        {
            get { return rue; }
            set { rue = value; }
        }


        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }

        public string Pays
        {
            get { return pays; }
            set { pays = value; }
        }

        public string CodePostal
        {
            get { return codePostal; }
            set { codePostal = value; }
        }
        #endregion


    }
}