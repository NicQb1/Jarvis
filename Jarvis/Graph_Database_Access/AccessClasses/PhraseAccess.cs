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
                 .Where(" phrase.phrase = '" + value + "'")
                 .Return(phrase => phrase.As<Phrase>())
                 .Results
                 .Single();
            return result;
        }
        public override List<Phrase> getMatchingNodes(Phrase node)
        {

            try
            {
                var results = client.Cypher
                    .Match("(phrase:Phrase)")
               .Where(" phrase.phrase = '" + node.phrase + "'")
               .Return(phrase => phrase.As<Phrase>())
               .Results.ToList();


                return results;
            }
            catch (Exception ex)
            { return null; }
        }

        public NodeReference<Phrase> InsertNode2(Phrase phrase, Dictionary<string, object> myDictionary)
        {
            List<NodeReference<Word>> nodeReferences = new List<NodeReference<Word>>();
            string[] words = phrase.phrase.Split(' ');
            NodeReference<Phrase> myPhrase = client.Create(new Phrase { phrase = phrase.phrase });

            int i = 0;
            foreach (string word in words)
            {

                var myNodeReference = client.Create(new Word { word = word });
                client.CreateRelationship(myNodeReference , new WordPhraseRelationship(myPhrase));

                nodeReferences.Add(myNodeReference);
                if (i > 0)
                {
                    AddEdge(nodeReferences[i - 1].Id, PhraseCommandRelationship.TypeKey, myNodeReference.Id, myDictionary);
                    // client.CreateRelationship((NodeReference<Word>)nodeReferences[i - 1], new WordToWordRelationship(myNodeReference));

                }
                i++;
            }
            return myPhrase;

        }
        public  Node<Phrase> InsertNode3(Phrase phrase, Dictionary<string, object> myDictionary)
        {
            List<NodeReference<Word>> nodeReferences = new List<NodeReference<Word>>();
            string[] words = phrase.phrase.Split(' ');
            NodeReference<Phrase> myPhrase = client.Create(new Phrase { phrase = phrase.phrase });
          
            int i = 0;
            foreach (string word in words)
            {

                var myNodeReference = client.Create(new Word { word = word });
                client.CreateRelationship(myNodeReference, new WordPhraseRelationship(myPhrase));

                nodeReferences.Add(myNodeReference);
                if (i > 0)
                {
                    AddEdge(nodeReferences[i - 1].Id, PhraseCommandRelationship.TypeKey, myNodeReference.Id, myDictionary);
                   // client.CreateRelationship((NodeReference<Word>)nodeReferences[i - 1], new WordToWordRelationship(myNodeReference));

                }
                i++;
            }
            return client.Get(myPhrase);
             
        }

        public bool Exists(Phrase node)
        {

            return client.Cypher.Match("(phrase:Phrase)")
                 .Where((Phrase phrase) => phrase.phrase == node.phrase)
                 .Return(phrase => phrase.As<Phrase>())
                 .Results
                 .Any();

        }

      
        public Phrase  InsertNode(Phrase node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(phrase:Phrase {phrase})")
                     .WithParam("phrase", node)
                     .Return(word => word.As<Phrase>())
                     .Results;
                var x = client.Get<Phrase>((NodeReference)results.First().Id);

                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }
            throw new NotImplementedException();
        }
        public NodeReference<Phrase> InsertNodeGetRef(Phrase node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(phrase:Phrase {phrase})")
                     .WithParam("phrase", node)
                     .Return(phrase => phrase.As<Phrase>())
                     .Results;
                var x = client.Get<Phrase>((NodeReference)results.First().Id);

                return x.Reference;
            }
            catch (Exception ex)
            {
                return null;
            }
            throw new NotImplementedException();
        }
    }
}
