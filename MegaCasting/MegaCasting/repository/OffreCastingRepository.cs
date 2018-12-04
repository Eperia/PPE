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
    class OffreCastingRepository
    {
        private static SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");

        public List<OffreCasting> Select()
        {
            List<OffreCasting> offreCastings = new List<OffreCasting>();

            try
            {
                SqlCommand commande = new SqlCommand("SelectOffreCasting", connection);
                commande.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    OffreCasting offreCasting = new OffreCasting();
                    offreCasting.Id = dataReader.GetInt64(0);
                    offreCasting.Id_Professionel = dataReader.GetInt64(1);
                    offreCasting.Id_Employe = dataReader.GetInt64(2);
                    offreCasting.Titre = dataReader.GetString(3);
                    offreCasting.dt_debut_publi = dataReader.GetDateTime(4);
                    offreCasting.dure_dif = dataReader.GetInt32(5);
                    offreCasting.dt_debut_contrat = dataReader.GetDateTime(6);
                    offreCasting.localisation = dataReader.GetString(7);
                    offreCasting.desc = dataReader.GetString(8);

                    offreCastings.Add(offreCasting);
                }

                connection.Close();
            }
            catch (Exception erreur)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
                connection.Close();
            }
            return offreCastings;
        }
    }
}
