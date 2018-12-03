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
    class PartenaireRepository
    {
        SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");
        //SqlConnection connection = new SqlConnection("Server=B02-11;Database=megacasting;User Id=sa;Password=SQL2014");

        /// <summary>
        /// Récupère toutes les données de la table "Partenaire"
        /// Utilise la procédure "SelectPartenaire"
        /// </summary>
        /// <returns> renvoie une List<Partenaire> </returns>
        public List<Partenaire> Select()
        {
            List<Partenaire> partenaires = new List<Partenaire>();

            try
            {
                SqlCommand commande = new SqlCommand("SelectPartenaire", connection);
                commande.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    Partenaire partenaire = new Partenaire();
                    partenaire.Id = dataReader.GetInt64(0);
                    partenaire.Libelle = dataReader.GetString(1);
                    partenaire.URL = dataReader.GetString(2);
                    partenaire.Telephone = dataReader.GetString(3);
                    partenaire.Rue = dataReader.GetString(4);
                    partenaire.Ville = dataReader.GetString(5);
                    partenaire.CodePostal = dataReader.GetString(6);
                    partenaire.Pays = dataReader.GetString(7);
                    partenaire.Email = dataReader.GetString(8);



                    if (!dataReader.IsDBNull(9))
                    {
                        partenaire.Fax = dataReader.GetString(9);
                    }
                    partenaires.Add(partenaire);
                }

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return partenaires;
        }

        /// <summary>
        /// Insert les données dans la table "Partenaire"
        /// Utilise la procédure "InsertPartenaire"
        /// </summary>
        /// <returns></returns>
        public void Insert(Partenaire partenaire)
        {
            try
            {


                SqlCommand commande = new SqlCommand("InsertPartenaire", connection);
                commande.CommandType = CommandType.StoredProcedure;
                connection.Open();

                commande.Parameters.Add("@libelle", SqlDbType.NVarChar).Value = partenaire.Libelle;
                commande.Parameters.Add("@URL", SqlDbType.NVarChar).Value = partenaire.URL;
                commande.Parameters.Add("@Rue", SqlDbType.NVarChar).Value = partenaire.Rue;
                commande.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = partenaire.Telephone;
                commande.Parameters.Add("@fax", SqlDbType.NVarChar).Value = partenaire.Fax;
                commande.Parameters.Add("@Ville", SqlDbType.NVarChar).Value = partenaire.Ville;
                commande.Parameters.Add("@CodePostal", SqlDbType.NVarChar).Value = partenaire.CodePostal;
                commande.Parameters.Add("@Pays", SqlDbType.NVarChar).Value = partenaire.Pays;
                commande.Parameters.Add("@email", SqlDbType.NVarChar).Value = partenaire.Email;
                commande.Parameters.Add("@mdp", SqlDbType.NVarChar).Value = MD5Sample.cryptage(partenaire.Mdp);


                SqlDataReader dataReader = commande.ExecuteReader();

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }


        }

        /// <summary>
        /// Mise à jour de la table "Partenaire"
        /// Utilise la procédure "UpdatePartenaire"
        /// </summary>
        /// <returns></returns>
        public void Update(Partenaire partenaire)
        {
            try
            {
                SqlCommand commande = new SqlCommand("UpdatePartenaire", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = partenaire.Id;
                commande.Parameters.Add("@libelle", SqlDbType.NVarChar).Value = partenaire.Libelle;
                commande.Parameters.Add("@URL", SqlDbType.NVarChar).Value = partenaire.URL;
                commande.Parameters.Add("@Rue", SqlDbType.NVarChar).Value = partenaire.Rue;
                commande.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = partenaire.Telephone;
                commande.Parameters.Add("@fax", SqlDbType.NVarChar).Value = partenaire.Fax;
                commande.Parameters.Add("@Ville", SqlDbType.NVarChar).Value = partenaire.Ville;
                commande.Parameters.Add("@CodePostal", SqlDbType.NVarChar).Value = partenaire.CodePostal;
                commande.Parameters.Add("@Pays", SqlDbType.NVarChar).Value = partenaire.Pays;
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
        /// supprimes les donnés qui sont lié a l'id de la table "Partenaire" fournis en paramètre
        /// Utilise la procédure "DeletePartenaire"
        /// </summary>
        /// <returns></returns>
        public void Delete(Int64 Id)
        {
            try
            {
                SqlCommand commande = new SqlCommand("DeletePartenaire", connection);
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

    }
}
