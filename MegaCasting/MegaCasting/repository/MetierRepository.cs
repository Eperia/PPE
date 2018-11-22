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
        SqlConnection connection = new SqlConnection("Server=B16-04\\SQLEXPRESS2017;Database=megacasting;Trusted_Connection=True;");
        
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
                    metier.domaineMetier.Id = dataReader.GetInt64(2);
                    metier.domaineMetier.Nom = dataReader.GetString(3);

                    metiers.Add(metier);
                }

                connection.Close();
            }
            catch (Exception)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return metiers;
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
