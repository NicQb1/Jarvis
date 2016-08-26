using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Database_Access
{
    public class PartOfSpeechLogic : SQLBaseLogic
    {
      

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
                    rdr.Close();
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                //  throw;
            }
            finally
            {
                con.Close();
            }
            return results;
        }

    }
}
