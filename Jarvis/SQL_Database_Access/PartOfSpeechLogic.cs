using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Database_Access
{
    public class PartOfSpeechLogic
    {
        private string _connectionstring = "Data Source=ITG5CB3083CM3;Initial Catalog=NLP_Statistic_db;Integrated Security=True";
        public string connectionString
        {
            get
            {
                return _connectionstring;
            }
            set
            {
                _connectionstring = value;
            }
        }
        private SqlConnection _con;
        public SqlConnection con
        {
            get
            {
                if (_con == null)
                {
                    _con = new SqlConnection(connectionString);
                }
                return _con;
            }
            set
            {
                _con = value;

            }
        }

        public int GetPartOfSpeech(string pos)
        {
            int results = 0;

            try
            {


                using (SqlCommand cmd = new SqlCommand("sp_GetPartOfSpeech", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@POS", SqlDbType.VarChar).Value = pos;
                    if (con.State == ConnectionState.Closed) 
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        results =(int)rdr[0];
                      

                    }
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return results;
        }

    }
}
