using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using Graph_Database_Access.Relationships;
using Net.Graph.Neo4JD;

namespace Graph_Database_Access.AccessClasses
{
    public class PhraseAccess : BaseAccess<Phrase>, IGDBAccess<Phrase>
    {
      

        public Phrase GetObjectClass(object value)
        {
           
           var result =
             client.Cypher.Match("(phrase:Phrase)")
                 .Where((Phrase phrase) => phrase.phrase == (string)value)
                 .Return(phrase => phrase.As<Phrase>())
                 .Results
                 .Single();
            return result;
        }

        public NodeReference<Phrase> InsertNode(Phrase phrase)
        {
            List<NodeReference<Word>> nodeReferences = new List<NodeReference<Word>>();
            string[] words = phrase.phrase.Split(' ');
            NodeReference<Phrase> myPhrase = client.Create(new Phrase { phrase = phrase.phrase });
          
            int i = 0;
            foreach (string word in words)
            {

                var myNodeReference = client.Create(new Word { word = word });
                client.CreateRelationship(myPhrase, new WordPhraseRelationship(myNodeReference));

                nodeReferences.Add(myNodeReference);
                if (i > 0)
                {
                    client.CreateRelationship((NodeReference<Word>)nodeReferences[i - 1], new WordToWordRelationship(myNodeReference));

                }
                i++;
            }
            return myPhrase;
        }
    }
}
