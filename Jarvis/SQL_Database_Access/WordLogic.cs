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
    public class WordLogic : SQLBaseLogic
    {
      

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

        public int InsertWord(WordDTO wd)
        {
            int wordId = 0;
            try
            {


                using (SqlCommand cmd = new SqlCommand("sp_insert_word", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@word", SqlDbType.VarChar).Value = wd.word;
                 //   cmd.Parameters.Add("@PartOfSpeech", SqlDbType.VarChar).Value = wd.partOfSpeech;
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
            finally
            {
                con.Close();
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
            finally
            {
                con.Close();
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

        public List<WordDTO> GetWordsAndIds()
        {
            List<WordDTO> results = new List<WordDTO>();
            try
            {


                using (SqlCommand cmd = new SqlCommand("SELECT   WordID, word, PartOfSpeechID FROM  Word", con))
                {
                    cmd.CommandType = CommandType.Text;
                    
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        WordDTO tmp = new WordDTO();

                        tmp.ID = (int)rdr[0];
                        tmp.word = rdr[1].ToString();
                        tmp.partOfSpeechID = int.Parse(rdr[2].ToString());
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
