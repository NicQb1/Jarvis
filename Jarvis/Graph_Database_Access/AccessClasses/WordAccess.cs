using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using Graph_Database_Access.Relationships;

namespace Graph_Database_Access.AccessClasses
{
    public class WordAccess : BaseAccess<Word>, IGDBAccess<Word>
    {

        public Word GetObjectClass(object value)
        {


            var result =
              client.Cypher.Match("(word:Word)")
                  .Where((Word word) => word.word == (string)value)
                  .Return(word => word.As<Word>())
                  .Results
                  .Single();
            return result;
        }



        public NodeReference<Word> InsertNode(Word myWord, Dictionary<string, object> myDictionary)
        {

            var myNodeReference = client.Create(myWord);
            //PhraseAccess pa = new PhraseAccess();
            //var phrasenode = pa.InsertNode(pa.GetObjectClass(myWord.word), myDictionary);

            return myNodeReference;
        }
    }
}
