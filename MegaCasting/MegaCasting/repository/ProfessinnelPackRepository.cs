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
    class ProfessinnelPackRepository
    {
        private static SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");

        internal void Insert(Int64 idPack,Int64 idProfessionnel)
        {
            try
            {
                SqlCommand commande = new SqlCommand("InsertProfessionnelPack", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id_PackCasting", SqlDbType.Float).Value = idPack;
                commande.Parameters.Add("@id_Professionnel", SqlDbType.BigInt).Value = idProfessionnel;

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
    }
}
