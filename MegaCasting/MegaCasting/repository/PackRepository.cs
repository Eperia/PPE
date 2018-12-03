using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCasting.Class;

namespace MegaCasting.repository
{
    class PackRepository
    {
        private static SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");

        internal List<Pack> Select()
        {
            List<Pack> packs = new List<Pack>();

            try
            {
                SqlCommand commande = new SqlCommand("SelectPackCasting", connection);
                commande.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    Pack pack = new Pack();
                    PrixPackRepository prixPackRepository = new PrixPackRepository();


                    pack.ID = dataReader.GetInt64(0);
                    pack.Libelle = dataReader.GetString(1);

                    pack.PrixPack = prixPackRepository.Select(pack.ID);
                    pack.NbrPoste = dataReader.GetInt32(2);


                    packs.Add(pack);
                }

                connection.Close();
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return packs;
        }

        public Int64 Insert(Pack pack)
        {
            Int64 id = 0;
            try
            {
                SqlCommand commande = new SqlCommand("InsertPackCasting", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@nom", SqlDbType.NVarChar).Value = pack.Libelle;
               // commande.Parameters.Add("@prix", SqlDbType.Float).Value = pack.Prix; // repositoryPrixPack
                commande.Parameters.Add("@nbrPoste", SqlDbType.Int).Value = pack.NbrPoste;

                commande.Parameters.Add("@IdReturn", SqlDbType.Int).Direction = ParameterDirection.Output;


                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                id = Convert.ToInt64(commande.Parameters["@IdReturn"].Value);

                connection.Close();
                PrixPackRepository prixPackRepository = new PrixPackRepository();

                prixPackRepository.Insert(pack, id);
            }
            catch (Exception test)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return id;

        }

        public void Update(Pack pack)
        {
            try
            {
                SqlCommand commande = new SqlCommand("UpdatePack", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = pack.ID;
                commande.Parameters.Add("@nom", SqlDbType.NVarChar).Value = pack.Libelle;
                PrixPackRepository prixPackRepository = new PrixPackRepository();
                if (prixPackRepository.Select(pack.ID).Prix == pack.PrixPack.Prix)
                {
                    commande.Parameters.Add("@prix", SqlDbType.Float).Value = 0;
                }
                else
                {
                    commande.Parameters.Add("@prix", SqlDbType.Float).Value = pack.PrixPack.Prix;

                }
                commande.Parameters.Add("@nbrPoste", SqlDbType.Int).Value = pack.NbrPoste;
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

        public void Delete(Int64 Id)
        {
            try
            {
                SqlCommand commande = new SqlCommand("DeleteDomaineMetier", connection);
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
        public bool VerifDomaineMetier_Metier(Int64 _Id)
        {
            bool isTrue = false;
            Int64 id = 0;
            try
            {
                SqlCommand commande = new SqlCommand("VerifDomaineMetier_Metier", connection);
                commande.CommandType = CommandType.StoredProcedure;

                commande.Parameters.Add("@id", SqlDbType.BigInt).Value = _Id;
                commande.Parameters.Add("@IdReturn", SqlDbType.Int).Direction = ParameterDirection.Output;


                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();
                id = Convert.ToInt64(commande.Parameters["@IdReturn"].Value);

                connection.Close();
                if (0 == id)
                {
                    isTrue = true;
                }
            }
            catch (Exception)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }

            return isTrue;
        }
    }
}
