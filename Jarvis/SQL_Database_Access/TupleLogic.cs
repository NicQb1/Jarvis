﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Database_Access
{
    public class TupleLogic : SQLBaseLogic
    {
     

        public int InsertTuple(int word1, int word2)
        {
            int results=0;
            try
            {


                using (SqlCommand cmd = new SqlCommand("sp_insertTupleN2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@wordID1", SqlDbType.Int).Value = word1;
                    cmd.Parameters.Add("@wordID2", SqlDbType.Int).Value = word2;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        results = (int)rdr[0];


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

        public int InsertTupleByStoredProc(string sp, int tupleId1, int tupleId2)
        {
            int results = 0;
            try
            {


                using (SqlCommand cmd = new SqlCommand(sp, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TupleID1", SqlDbType.Int).Value = tupleId1;
                    cmd.Parameters.Add("@TupleID2", SqlDbType.Int).Value = tupleId2;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.Read())
                    {
                        results = (int)rdr[0];


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
