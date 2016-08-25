using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;

namespace SQL_Database_Access
{
    public class WordLogic
    {
        private string _connectionstring = "Data Source=DESKTOP-T3GHSNR;Initial Catalog=NLP_Statistic_db;Integrated Security=True";
        public string connectionString { get {
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

        private List<int> getWordID(string word)
        {
            List<int> results = new List<int>();

            try
            {
                string commandText = "SELECT WordID FROM Word w where w.word = '" + word + "'";

                using (SqlCommand cmd = new SqlCommand(commandText, con))
                {
                    cmd.CommandType = CommandType.Text;

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        int tmp = (int)rdr["ID"];

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

        public int InsertWord(WordDTO wd)
        {
            int wordId = 0;
            try
            {


                using (SqlCommand cmd = new SqlCommand("sp_insert_word", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@word", SqlDbType.VarChar).Value = wd.word;
                    cmd.Parameters.Add("@PartOfSpeech", SqlDbType.VarChar).Value = wd.partOfSpeech;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        wordId = (int)rdr[0];

                    }
                    rdr.Close();
                }

                foreach (var syn in wd.synonyms)
                {
                    insertSynonyms(wordId, syn);
                }

                foreach (var ant in wd.antonyms)
                {

                    insertAntonyms(wordId, ant);
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return wordId;


        }
        public int InsertWordAndPOS(string wd, int posId)
        {
            int wordId = 0;
            try
            {


                using (SqlCommand cmd = new SqlCommand("sp_insert_word_and_POS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@word", SqlDbType.VarChar).Value = wd;
                    cmd.Parameters.Add("@PartOfSpeech", SqlDbType.Int).Value = posId;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        wordId = (int)rdr[0];

                    }
                    rdr.Close();
                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
            return wordId;


        }
        private void insertAntonyms(int wordId, AntonymDTO wd)
        {
            try
            {


                using (SqlCommand cmd = new SqlCommand("sp_insert_Antonym", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@wordID", SqlDbType.Int).Value = wordId;
                    cmd.Parameters.Add("@ant", SqlDbType.VarChar).Value = wd.word;
                    cmd.Parameters.Add("@complexity", SqlDbType.Int).Value = wd.complexity;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();

                }


            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        private void insertSynonyms(int wordId, SynonymDTO wd)
        {
            try
            {


                using (SqlCommand cmd = new SqlCommand("sp_insert_Synonym", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@wordID", SqlDbType.Int).Value = wordId;
                    cmd.Parameters.Add("@syn", SqlDbType.VarChar).Value = wd.word;
                    cmd.Parameters.Add("@complexity", SqlDbType.Int).Value = wd.complexity;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                     cmd.ExecuteNonQuery();
                   
                }
               

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }

        }
    }
}
