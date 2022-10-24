using AdresbeheerBL.Interfaces;
using AdresbeheerBL.Model;
using AdresbeheerDL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerDL.Repositories
{
    public class GemeenteRepositoryADO : IGemeenteRepository
    {
        private string connectionString;

        public GemeenteRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Gemeente GeefGemeente(int gemeenteId)
        {
            string query = "SELECT * FROM Gemeente where NIScode=@niscode";
            SqlConnection conn = new SqlConnection(connectionString);
            using(SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@niscode",gemeenteId);
                    IDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();
                    Gemeente gemeente = new Gemeente((int)dataReader["NIScode"],(string)dataReader["gemeentenaam"]);
                    dataReader.Close();
                    return gemeente;
                }
                catch (Exception ex)
                {
                    throw new GemeenteRepositoryException("Geefgemeente", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
