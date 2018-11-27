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
        // SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");
        SqlConnection connection = new SqlConnection("Server=B02-11;Database=megacasting;User Id=sa;Password=SQL2014");

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
                    partenaire.Adresse = dataReader.GetString(3);
                    partenaire.Telephone = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5))
                    {
                        partenaire.Fax = dataReader.GetString(5);

                    }
                    partenaires.Add(partenaire);
                }

                connection.Close();
            }
            catch (Exception)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return partenaires;
        }

        public void Insert(Partenaire partenaire)
        {
            try
            {


                SqlCommand commande = new SqlCommand("InsertPartenaire", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@libelle", SqlDbType.NVarChar).Value = partenaire.Libelle;
                commande.Parameters.Add("@URL", SqlDbType.NVarChar).Value = partenaire.URL;
                commande.Parameters.Add("@adresse", SqlDbType.NVarChar).Value = partenaire.Adresse;
                commande.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = partenaire.Telephone;
                commande.Parameters.Add("@fax", SqlDbType.NVarChar).Value = partenaire.Fax;
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

        public void Update(Partenaire partenaire)
        {
            try
            {
                SqlCommand commande = new SqlCommand("UpdatePartenaire", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = partenaire.Id;
                commande.Parameters.Add("@libelle", SqlDbType.NVarChar).Value = partenaire.Libelle;
                commande.Parameters.Add("@URL", SqlDbType.NVarChar).Value = partenaire.URL;
                commande.Parameters.Add("@adresse", SqlDbType.NVarChar).Value = partenaire.Adresse;
                commande.Parameters.Add("@telephone", SqlDbType.NVarChar).Value = partenaire.Telephone;
                commande.Parameters.Add("@fax", SqlDbType.NVarChar).Value = partenaire.Fax;
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
