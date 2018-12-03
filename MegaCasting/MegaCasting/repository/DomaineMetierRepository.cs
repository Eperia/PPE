using MegaCasting.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCasting.repository
{
    class DomaineMetierRepository
    {
       // SqlConnection connection = new SqlConnection("Server=B02-11;Database=megacasting;User Id=sa;Password=SQL2014");
        SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");

        /// <summary>
        /// Récupère toutes les données de la table "DomaineMetier"
        /// Utilise la procédure "SelectDomaineMetier"
        /// </summary>
        /// <returns> renvoie une List<DomaineMetier> </returns>
        public List<DomaineMetier> Select()
        {
            List<DomaineMetier> domaineMetiers = new List<DomaineMetier>();

            try
            {
                SqlCommand commande = new SqlCommand("SelectDomaineMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    DomaineMetier domaineMetier = new DomaineMetier();


                    domaineMetier.Id = dataReader.GetInt64(0);
                    domaineMetier.Nom = dataReader.GetString(1);


                    domaineMetiers.Add(domaineMetier);
                }

                connection.Close();
            }
            catch (Exception)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return domaineMetiers;
        }
        /// <summary>
        /// Récupère l'id qui correspond au nom du domaine métier
        /// Utilise la procédure "SelectIdDomaineMetier"
        /// </summary>
        /// <returns> renvoie un Int64 </returns>
        public Int64 SelectId(string nom)
        {
            Int64 idDomaineMetier = 0;
            try
            {
                SqlCommand commande = new SqlCommand("SelectIdDomaineMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@Nom", SqlDbType.NVarChar).Value = nom;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    idDomaineMetier = dataReader.GetInt64(0);
                }

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return idDomaineMetier;
        }
        /// <summary>
        /// Récupère le nom qui correspond a l'id du domaine métier 
        /// Utilise la procédure "SelectNameDomaineMetier"
        /// </summary>
        /// <returns> renvoie une string </returns>
        public string SelectName(Int64 id)
        {
            string name = "";
            try
            {
                SqlCommand commande = new SqlCommand("SelectNameDomaineMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    name = dataReader.GetString(0);
                }

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return name;
        }

        /// <summary>
        /// Insert le nom et retourn l'id insérer
        /// Utilise la procédure "InsertDomaineMetier"
        /// </summary>
        /// <returns> renvoie un Int64 </returns>
        public Int64  Insert(DomaineMetier domaineMetier)
        {
            Int64 id = 0;
            try
            {


                SqlCommand commande = new SqlCommand("InsertDomaineMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;
                
                commande.Parameters.Add("@nom", SqlDbType.NVarChar).Value = domaineMetier.Nom;
                commande.Parameters.Add("@IdReturn", SqlDbType.Int).Direction = ParameterDirection.Output;


                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                id = Convert.ToInt64(commande.Parameters["@IdReturn"].Value);

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return id;

        }

        /// <summary>
        /// Mise à jour de la table DomaineMetier
        /// Utilise la procédure "UpdateDomaineMetier"
        /// </summary>
        /// <returns></returns>
        public void Update(DomaineMetier domaineMetier)
        {
            try
            {
                SqlCommand commande = new SqlCommand("UpdateDomaineMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = domaineMetier.Id;
                commande.Parameters.Add("@nom", SqlDbType.NVarChar).Value = domaineMetier.Nom;
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();


                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
                connection.Close();
            }




        }

        /// <summary>
        /// supprimes les donnés qui sont lié a l'id de la table "DomaineMetier" fournis en paramètre
        /// Utilise la procédure "DeleteDomaineMetier"
        /// </summary>
        /// <returns></returns>
        public void Delete(Int64 Id)
        {
            try
            {
                SqlCommand commande = new SqlCommand("DeleteDomaineMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = Id;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                connection.Close();
            }
            catch (Exception)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }




        }

        /// <summary>
        /// Verif si le domaine metier est lié à un métier
        /// Utilise la procédure "VerifDomaineMetier_Metier"
        /// </summary>
        /// <returns>renvoie un bool</returns>
        public bool VerifDomaineMetier_Metier(Int64 _Id) {
            bool isTrue = false;
            Int64 id = 0;
            try
            {
                SqlCommand commande = new SqlCommand("VerifDomaineMetier_Metier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = _Id;
                commande.Parameters.Add("@IdReturn", SqlDbType.Int).Direction = ParameterDirection.Output;


                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                id = Convert.ToInt64(commande.Parameters["@IdReturn"].Value);

                connection.Close();
                if ( 0 == id)
                {
                    isTrue = true;
                }
            }
            catch (Exception)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }

            return isTrue;
        }
    }
}
