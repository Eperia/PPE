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
    class MetierRepository
    {
        //SqlConnection connection = new SqlConnection("Server=B02-11;Database=megacasting;User Id=sa;Password=SQL2014");
        private static SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");

        /// <summary>
        /// Récupère toutes les données de la table "Metier"
        /// Utilise la procédure "SelectMetier"
        /// </summary>
        /// <returns> renvoie une List<Metier> </returns>
        public List<Metier> Select()
        {
            List<Metier> metiers = new List<Metier>();
            
            try
            {
                SqlCommand commande = new SqlCommand("SelectMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    Metier metier = new Metier();


                    metier.Id = dataReader.GetInt64(0);
                    metier.Nom = dataReader.GetString(1);
                    metier.Id_DomaineMetier = dataReader.GetInt64(2);

                    metiers.Add(metier);
                }

                connection.Close();
            }
            catch (Exception exeption)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return metiers;
        }

        /// <summary>
        /// Insert les données dans la table "Metier" et retourne l'id insérer
        /// Utilise la procédure "InsertMetier"
        /// </summary>
        /// <returns> renvoie un Int64 </returns>
        public Int64 Insert(Metier metier)
        {
            Int64 id = 0;
            try
            {


                SqlCommand commande = new SqlCommand("InsertMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@Nom", SqlDbType.NVarChar).Value = metier.Nom;
                commande.Parameters.Add("@Id_DomaineMetier", SqlDbType.NVarChar).Value = metier.Id_DomaineMetier;
                commande.Parameters.Add("@IdReturn", SqlDbType.Int).Direction = ParameterDirection.Output;


                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                id = Convert.ToInt64(commande.Parameters["@IdReturn"].Value);
                connection.Close();
            }
            catch (Exception exeption)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return id;

        }

        /// <summary>
        /// Mise à jour de la table "Metier"
        /// Utilise la procédure "UpdateMetier"
        /// </summary>
        /// <returns></returns>
        public void Update(Metier metier)
        {
            try
            {
                SqlCommand commande = new SqlCommand("UpdateMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = metier.Id;
                commande.Parameters.Add("@Nom", SqlDbType.NVarChar).Value = metier.Nom;
                commande.Parameters.Add("@Id_DomaineMetier", SqlDbType.NVarChar).Value = metier.Id_DomaineMetier;
                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();


                
            }
            catch (Exception test) 
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            connection.Close();



        }

        /// <summary>
        /// supprimes les donnés qui sont lié a l'id de la table "Metier" fournis en paramètre
        /// Utilise la procédure "DeleteMetier"
        /// </summary>
        /// <returns></returns>
        public void Delete(Int64 Id)
        {
            try
            {
                SqlCommand commande = new SqlCommand("DeleteMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = Id;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }



        }

    }
}
