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
    public class StraatRepositoryADO : IStraatRepository
    {

        private string connectionString;

        public StraatRepositoryADO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Straat> GeefStratenGemeente(int gemeenteId)
        {
            string query = "SELECT t1.*,t2.gemeentenaam FROM Straat t1 inner join Gemeente t2 on t1.NIScode=t2.NIScode where t1.NIScode=@niscode ";
            SqlConnection conn = new SqlConnection(connectionString);
            using(SqlCommand cmd = conn.CreateCommand())
            {
                try
                {
                    List<Straat> straten = new List<Straat>();
                    conn.Open();
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@niscode", gemeenteId);
                    IDataReader dr = cmd.ExecuteReader();
                    Gemeente gemeente = null;
                    while (dr.Read())
                    {
                        if(gemeente == null)
                        {
                            gemeente = new Gemeente((int)dr["NIScode"], (string)dr["gemeentenaam"]);
                        }
                        Straat straat = new Straat((int)dr["Id"], (string)dr["StraatNaam"], gemeente);
                        straten.Add(straat);
                    }
                    dr.Close();
                    return straten;
                }
                catch(Exception ex)
                {
                    throw new StraatRepositoryADOException("GeefStratenGemeente", ex);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
