using Common.DTO;
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

        public List<PosDTO> GetPOSAndIds()
        {
            List<PosDTO> results = new List<PosDTO>();
            try
            {


                using (SqlCommand cmd = new SqlCommand("SELECT  PartOfSpeechID, PartOfSpeech, lastUpdated FROM   PartOfSpeech", con))
                {
                    cmd.CommandType = CommandType.Text;

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        PosDTO tmp = new PosDTO();

                        tmp.ID = (int)rdr[0];
                        tmp.pos = rdr[1].ToString();
                        results.Add(tmp);

                    }
                    rdr.Close();

                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            finally
            {
                con.Close();
            }
            return results;


        }
    }
}
