using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;
using Neurons;
using Net.Graph;
using Net.Graph.Neo4JD;
using Neo4jClient;
using Graph_Database_Access.Relationships;
using Graph_Database_Access.BusinessObjects;
using Graph_Database_Access.AccessClasses;
using System.IO;

namespace Graph_Database_Access
{
    public class GraphDB
    {
       
        public void CreateIndexes()
        {

        }



        private void EnterWord(string word)
        {
            var myword = new Word();
            myword.currentExitation = 0;
            myword.firePoint = 5;
            myword.lastFired = DateTime.Now;
            myword.word = word;
            WordAccess wa = new WordAccess();
            //if (wa.getMatchingNodes(myword) == null)
            //{
            //    wa.InsertNode(myword, new Dictionary<string, object>());
            //}
            wa.InsertNode(myword, new Dictionary<string, object>());
        }

        public void SendPhrase(string phrase)
        {
            var phr = new Phrase();
            phr.phrase = phrase;
            PhraseAccess pa = new PhraseAccess();
           var phraseList =  pa.getMatchingNodes(phr);
            if(phraseList.Count == 0)
            {
                pa.InsertNode(phr, new Dictionary<string, object>());
            }

        }

        public void LoadDictionaryFile(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string myword;
                    while(!sr.EndOfStream)
                    {
                        myword = sr.ReadLine();
                        EnterWord(myword);
                    }
                   
                }
            }
            catch (Exception ex)
            {
               
            }
            
        }
    }
}
