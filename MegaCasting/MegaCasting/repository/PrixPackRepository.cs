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
    class PrixPackRepository
    {
        private static SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");

        internal PrixPack Select(Int64 _Id)
        {
            PrixPack prixPack = new PrixPack();
            try
            {
                SqlCommand commande = new SqlCommand("SelectPrixPack", connection);
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@id", SqlDbType.NVarChar).Value = _Id;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    


                    prixPack.Id = dataReader.GetInt64(0);
                    prixPack.Prix = dataReader.GetDouble(1);
                    prixPack.Dt_Debut = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3))
                    {
                        prixPack.Dt_Fin = dataReader.GetDateTime(3);
                    }

                    
                }

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return prixPack;
        }

        internal void Insert(Pack pack, long id)
        {
                try
                {
                    SqlCommand commande = new SqlCommand("InsertPrixPack", connection);
                    commande.CommandType = CommandType.StoredProcedure;

                    commande.Parameters.Add("@prix", SqlDbType.Float).Value = pack.PrixPack.Prix;
                    // commande.Parameters.Add("@prix", SqlDbType.Float).Value = pack.Prix; // repositoryPrixPack
                    commande.Parameters.Add("@Id_PackCasting", SqlDbType.BigInt).Value = id;

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