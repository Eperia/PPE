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
                    professionnel.Adresse = dataReader.GetString(3);
                    professionnel.Telephone = dataReader.GetString(4);
                   
                    if (!dataReader.IsDBNull(5))
                    {
                        professionnel.Fax = dataReader.GetString(5);

                    }
                    professionnel.Email = dataReader.GetString(6);
                    professionnel.NbrPoste = dataReader.GetInt32(7); 
                    professionnels.Add(professionnel);
                }

                connection.Close();
            }
            catch (Exception erreur)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return professionnels;
        }

        public void Insert(Professionnel professionnel)
        {
            try
            {


                SqlCommand commande = new SqlCommand("InsertProfessionnel", connection);
                commande.CommandType = CommandType.StoredProcedure;



                commande.Parameters.Add("@libelle", SqlDbType.NVarChar).Value = professionnel.Libelle;
                commande.Parameters.Add("@URL", SqlDbType.NVarChar).Value = professionnel.URL;
                commande.Parameters.Add("@adresse", SqlDbType.NVarChar).Value = professionnel.Adresse;
                commande.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = professionnel.Telephone;
                commande.Parameters.Add("@fax", SqlDbType.NVarChar).Value = professionnel.Fax;
                commande.Parameters.Add("@email", SqlDbType.NVarChar).Value = professionnel.Email;
                commande.Parameters.Add("@nbrPost", SqlDbType.Int).Value = professionnel.NbrPoste;
                commande.Parameters.Add("@mdp", SqlDbType.Int).Value = MD5Sample.cryptage(professionnel.Mdp);


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

        public void Update(Professionnel professionnel)
        {
            try
            {
                SqlCommand commande = new SqlCommand("UpdateProfessionnel", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = professionnel.Id;
                commande.Parameters.Add("@libelle", SqlDbType.NVarChar).Value = professionnel.Libelle;
                commande.Parameters.Add("@URL", SqlDbType.NVarChar).Value = professionnel.URL;
                commande.Parameters.Add("@adresse", SqlDbType.NVarChar).Value = professionnel.Adresse;
                commande.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = professionnel.Telephone;
                commande.Parameters.Add("@fax", SqlDbType.NVarChar).Value = professionnel.Fax;
                commande.Parameters.Add("@email", SqlDbType.NVarChar).Value = professionnel.Email;
                commande.Parameters.Add("@nbrPost", SqlDbType.NVarChar).Value = professionnel.NbrPoste;
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