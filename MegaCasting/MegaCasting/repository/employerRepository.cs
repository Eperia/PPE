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
    class EmployerRepository
    {
        SqlConnection connection = new SqlConnection("Server=localhost;Database=megacasting;Trusted_Connection=True;");

       
        public List<Employer> Select()
        {
            List<Employer> employers = new List<Employer>();

            try
            {
                SqlCommand commande = new SqlCommand("SelectEmploye", connection);
                commande.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader dataReader = commande.ExecuteReader();

                while (dataReader.Read())
                {

                    Employer employe = new Employer();


                    employe.Id = dataReader.GetInt64(0);
                    employe.Nom = dataReader.GetString(1);
                    employe.Prenom = dataReader.GetString(2);
                    employe.Email = dataReader.GetString(3);
                    employe.Id_TypeUtilisateur = dataReader.GetInt64(4);
                    employe.mdp = dataReader.GetString(5);

                    employers.Add(employe);
                }

                connection.Close();
            }
            catch (Exception)
            {
                ErreurBDD erreurBDD = new ErreurBDD();
                erreurBDD.ShowDialog();
            }
            return employers;
        }
    }
}
