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
        public void createWordDefinitionRelationship(NodeReference<Definition> mdR, NodeReference<Word> mwR)
        {
            client.CreateRelationship(mwR, new WordDefinitionRelationship(mdR));


        }
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

        internal PartOfSpeech GetPartOfSpeech(string word)
        {
            throw new NotImplementedException();
        }

        public override Node<Word> InsertNode(Word myWord, Dictionary<string, object> myDictionary)
        {

            var myNodeReference = client.Create(myWord);
            return client.Get(myNodeReference);
           
        }
        public NodeReference<Word> InsertNode2(Word myWord, Dictionary<string, object> myDictionary)
        {

            var myNodeReference = client.Create(myWord);
            return myNodeReference;

        }
    }
}
