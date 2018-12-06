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
   public class HistoriquePackRepository
    {
        internal List<HistoriquePack> Select(Professionnel _professionnel)
        {
            SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");
            PackRepository packRepository = new PackRepository();

            List<HistoriquePack> historiquePacks = new List<HistoriquePack>();

            try
            {
                SqlCommand commande = new SqlCommand("SelectHistoriquePack", connection);
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@id", SqlDbType.NVarChar).Value = _professionnel.Id;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    HistoriquePack historiquePack = new HistoriquePack();


                    historiquePack.dt_Achat = dataReader.GetDateTime(0);
                    historiquePack.professionnel = _professionnel;

                    historiquePack.pack = packRepository.Select(dataReader.GetInt64(1), historiquePack.dt_Achat);

                    historiquePacks.Add(historiquePack);
                }

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return historiquePacks;
        }


    }
}
