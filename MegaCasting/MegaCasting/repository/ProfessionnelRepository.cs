using MegaCasting.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace MegaCasting.repository
{
    class ProfessionnelRepository
    {

        //SqlConnection connection = new SqlConnection("Server=B02-11;Database=megacasting;User Id=sa;Password=SQL2014");
        SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");

        /// <summary>
        /// Récupère toutes les données de la table "Professionnel"
        /// Utilise la procédure "SelectProfessionnel"
        /// </summary>
        /// <returns> renvoie une List<Professionnel> </returns>
        public List<Professionnel> Select()
        {
            List<Professionnel> professionnels = new List<Professionnel>();

            try
            {
                SqlCommand commande = new SqlCommand("SelectProfessionnel", connection);
                commande.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    Professionnel professionnel = new Professionnel();
                    professionnel.Id = dataReader.GetInt64(0);
                    professionnel.Libelle = dataReader.GetString(1);
                    professionnel.URL = dataReader.GetString(2);
                    professionnel.Telephone = dataReader.GetString(3);
                    professionnel.Rue = dataReader.GetString(4);
                    professionnel.Ville = dataReader.GetString(5);
                    professionnel.CodePostal = dataReader.GetString(6);
                    professionnel.Pays = dataReader.GetString(7);
                    professionnel.Email = dataReader.GetString(8);

                    if (!dataReader.IsDBNull(9))
                    {
                        professionnel.Fax = dataReader.GetString(9);

                    }
                    professionnel.NbrPoste = dataReader.GetInt32(10); 
                    professionnels.Add(professionnel);
                }

                connection.Close();
            }
            catch (Exception erreur)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
                connection.Close();
            }
            return professionnels;
        }

        public Professionnel Select(Int64 id)
        {
            Professionnel professionnel = new Professionnel();

            try
            {
                SqlCommand commande = new SqlCommand("SelectOneProfessionnel", connection);
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = id;


                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                while (dataReader.Read())
                {

                    
                    professionnel.Id = dataReader.GetInt64(0);
                    professionnel.Libelle = dataReader.GetString(1);
                    professionnel.URL = dataReader.GetString(2);
                    professionnel.Telephone = dataReader.GetString(3);
                    professionnel.Rue = dataReader.GetString(4);
                    professionnel.Ville = dataReader.GetString(5);
                    professionnel.CodePostal = dataReader.GetString(6);
                    professionnel.Pays = dataReader.GetString(7);
                    professionnel.Email = dataReader.GetString(8);

                    if (!dataReader.IsDBNull(9))
                    {
                        professionnel.Fax = dataReader.GetString(9);

                    }
                    professionnel.NbrPoste = dataReader.GetInt32(10);
                }

                connection.Close();
            }
            catch (Exception erreur)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
                connection.Close();
            }
            return professionnel;
        }

        /// <summary>
        /// Insert les données dans la table "Professionnel"
        /// Utilise la procédure "InsertProfessionnel"
        /// </summary>
        /// <returns></returns>
        public void Insert(Professionnel professionnel)
        {
            try
            {


                SqlCommand commande = new SqlCommand("InsertProfessionnel", connection);
                commande.CommandType = CommandType.StoredProcedure;



                commande.Parameters.Add("@libelle", SqlDbType.NVarChar).Value = professionnel.Libelle;
                commande.Parameters.Add("@URL", SqlDbType.NVarChar).Value = professionnel.URL;
                commande.Parameters.Add("@Rue", SqlDbType.NVarChar).Value = professionnel.Rue;
                commande.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = professionnel.Telephone;
                commande.Parameters.Add("@fax", SqlDbType.NVarChar).Value = professionnel.Fax;
                commande.Parameters.Add("@Ville", SqlDbType.NVarChar).Value = professionnel.Ville;
                commande.Parameters.Add("@CodePostal", SqlDbType.NVarChar).Value = professionnel.CodePostal;
                commande.Parameters.Add("@Pays", SqlDbType.NVarChar).Value = professionnel.Pays;
                commande.Parameters.Add("@email", SqlDbType.NVarChar).Value = professionnel.Email;
                commande.Parameters.Add("@nbrPost", SqlDbType.Int).Value = professionnel.NbrPoste;
                commande.Parameters.Add("@mdp", SqlDbType.NVarChar).Value = MD5Sample.cryptage(professionnel.Mdp);

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                connection.Close();
            }
            catch (Exception erreur)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }


        }

        /// <summary>
        /// Mise à jour de la table "Professionnel"
        /// Utilise la procédure "UpdateProfessionnel"
        /// </summary>
        /// <returns></returns>
        public void Update(Professionnel professionnel)
        {
            try
            {
                string procedure = "";
                SqlCommand commande = new SqlCommand();
                if (!string.IsNullOrWhiteSpace(professionnel.Mdp.ToString()))
                {
                    SqlCommand commandeBis = new SqlCommand("UpdateProfessionnelWithmdp", connection);
                    commande = commandeBis;
                    commande.Parameters.Add("@mdp", SqlDbType.NVarChar).Value = MD5Sample.cryptage(professionnel.Mdp);

                }
                else
                {
                    SqlCommand commandeBis = new SqlCommand("UpdateProfessionnel", connection);
                    commande = commandeBis;


                }
                
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@id", SqlDbType.NVarChar).Value = professionnel.Id;
                commande.Parameters.Add("@libelle", SqlDbType.NVarChar).Value = professionnel.Libelle;
                commande.Parameters.Add("@URL", SqlDbType.NVarChar).Value = professionnel.URL;
                commande.Parameters.Add("@Rue", SqlDbType.NVarChar).Value = professionnel.Rue;
                commande.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = professionnel.Telephone;
                commande.Parameters.Add("@fax", SqlDbType.NVarChar).Value = professionnel.Fax;
                commande.Parameters.Add("@Ville", SqlDbType.NVarChar).Value = professionnel.Ville;
                commande.Parameters.Add("@CodePostal", SqlDbType.NVarChar).Value = professionnel.CodePostal;
                commande.Parameters.Add("@Pays", SqlDbType.NVarChar).Value = professionnel.Pays;
                commande.Parameters.Add("@email", SqlDbType.NVarChar).Value = professionnel.Email;
                commande.Parameters.Add("@nbrPost", SqlDbType.Int).Value = professionnel.NbrPoste;


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
        /// supprimes les donnés qui sont lié a l'id de la table "Professionnel" fournis en paramètre
        /// Utilise la procédure "DeleteProfessionnel"
        /// </summary>
        /// <returns></returns>
        public void Delete(Int64 Id)
        {
            try
            {
                SqlCommand commande = new SqlCommand("DeleteProfessionnel", connection);
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