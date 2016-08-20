﻿using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace SQL_Database_Access
{
    public class PhraseLogic
    {
        public string connectionString { get; private set; }
        private SqlConnection _con;
        public SqlConnection con { get
            {
                if(_con == null)
                {
                    _con = new SqlConnection(connectionString);
                }
                return _con;
            }  set
            {
                _con = value;

            } }

        public List<NodeReferenceStats> InsertPhraseForStatAnalysis(string phrase)
        {
            List<NodeReferenceStats> results = new List<NodeReferenceStats>();
            try
            {
                string[] words = phrase.Split(' ');
                List<NodeReferenceStats> tupleReferences = new List<NodeReferenceStats>();

                for (int i = 0; i < words.Length - 1; i++)
                {
                    tupleReferences.AddRange(UpsertTuple(words[i], words[i + 1]));
                }
                for (int i = 0; i < tupleReferences.Count - 1; i++)
                {
                    results.AddRange(UpsertTupleAssociation(tupleReferences[i], tupleReferences[i + 1]));
                }
                results.AddRange(tupleReferences);


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;

            }

            return results;

        }

        private List<NodeReferenceStats> UpsertTupleAssociation(NodeReferenceStats nodeReferenceStats1, NodeReferenceStats nodeReferenceStats2)
        {
            List<NodeReferenceStats> results = new List<NodeReferenceStats>();

            try
            {


                using (SqlCommand cmd = new SqlCommand("sp_UpsertTupleRef", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@tuple1", SqlDbType.VarChar).Value = nodeReferenceStats1.ID;
                    cmd.Parameters.Add("@tuple2", SqlDbType.VarChar).Value = nodeReferenceStats2.ID;
                    if (con.State == ConnectionState.Closed) ;
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        NodeReferenceStats tmp = new NodeReferenceStats();
                        tmp.ID = (long)rdr["ID"];
                        tmp.percent = (decimal)rdr["percent"];
                        tmp.type = (string)rdr["type"];
                        results.Add(tmp);

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

        private List<NodeReferenceStats> UpsertTuple(string word1, string word2)
        {
            List<NodeReferenceStats> results = new List<NodeReferenceStats>();
           
            try
            {
              

                using (SqlCommand cmd = new SqlCommand("sp_UpsertTuple", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@word1", SqlDbType.VarChar).Value = word1;
                    cmd.Parameters.Add("@word2", SqlDbType.VarChar).Value = word2;
                    if (con.State == ConnectionState.Closed) ;
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        NodeReferenceStats tmp = new NodeReferenceStats();
                        tmp.ID = (long)rdr["ID"];
                        tmp.percent = (decimal)rdr["percent"];
                        tmp.type = (string)rdr["type"];
                        results.Add(tmp);

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