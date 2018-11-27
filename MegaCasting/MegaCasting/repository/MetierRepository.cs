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
        SqlConnection connection = new SqlConnection("Server=B02-11;Database=megacasting;User Id=sa;Password=SQL2014");


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

        public void Insert(Metier metier)
        {
            try
            {


                SqlCommand commande = new SqlCommand("InsertMetier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@Nom", SqlDbType.NVarChar).Value = metier.Nom;
                commande.Parameters.Add("@Id_DomaineMetier", SqlDbType.NVarChar).Value = metier.Id_DomaineMetier;

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


                connection.Close();
            }
            catch (Exception test) 
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }




        }

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
            catch (Exception)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }



        }

    }
}
