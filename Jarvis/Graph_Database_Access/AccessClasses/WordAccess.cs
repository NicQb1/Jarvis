using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using Graph_Database_Access.Relationships;
using Common.DTO;

namespace Graph_Database_Access.AccessClasses
{
    public class WordAccess : BaseAccess<Word>, IGDBAccess<Word>
    {
        #region relationships
        public void createWordDefinitionRelationship(NodeReference<Definition> mdR, NodeReference<Word> mwR)
        {
            client.CreateRelationship(mwR, new WordDefinitionRelationship(mdR));


        }
        public void createWordPOSRelationship(NodeReference<PartOfSpeech> mdR, NodeReference<Word> mwR)
        {
            client.CreateRelationship(mwR, new WordToPOSRelationship(mdR));
        }

        public void createWordPhraseRelationship(NodeReference<Phrase> mdR, NodeReference<Word> mwR)
        {
            client.CreateRelationship(mwR, new WordPhraseRelationship(mdR));
        }


        #endregion

        #region get methods
        public override NodeReference<Word> getMatchingNodeReference(Word node, Dictionary<string, object> myDictionary)
        {
            try
            {
                var results = client.Cypher.Match("(word:word)")
                      .Where(" word.word = '" + node.word + "'")
                     .Return<Word>("x");
                if (results == null)
                {
                    return client.Create(node);
                }


                return (NodeReference<Word>)results;
            }
            catch (Exception ex)
            { return null; }
        }


        public override List<Word> getMatchingNodes(Word node)
        {

            try
            {
                var results = client.Cypher
                    .Match("(word:Word)")
               .Where(" word.word = '" + node.word + "'")
               .Return(word => word.As<Word>())
               .Results.ToList();


                return results;
            }
            catch (Exception ex)
            { return null; }
        }
        public Word GetObjectClass(object value)
        {


            var result =
              client.Cypher.Match("(word:Word)")
                   .Where(" word.word = '" + value + "'")
                  .Return(word => word.As<Word>())
                  .Results
                  .Single();
            return result;
        }

        public PartOfSpeech GetPartOfSpeech(string _word)
        {

        
            var result = client.Cypher
                .Match("(word:Word)-[Word_To_POS]-(pos:PartOfSpeech)")
                .Where((Word word) => word.Id == 1234)
                 .ReturnDistinct((pos) => new
                    {
                     NumberOfFriends = pos.As<PartOfSpeech>()
                      })
                 .Results;

            PartOfSpeechAccess pa = new PartOfSpeechAccess();
            return pa.getPOS(result.FirstOrDefault());
        }

        public bool Exists(Word node)
        {


            return client.Cypher
                  .Match("(word:Word)")
                  .Where(" word.word = '" + node.word + "'")
                  .Return(pos => pos.As<Word>())
                  .Results
                  .Any();

        }
        #endregion

        #region Insert methods
        public virtual IEnumerable<Word> CreateNode(Word node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(word:Word {word})")
                     .WithParam("word", node)
                     .WithParams(myDictionary)
                     .Return(word => word.As<Word>())
                     .Results;

                return results;
            }catch(Exception ex)
            {
                return null;
            }

        }

        public  Word InsertNode(Word node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(word:Word {word})")
                     .WithParam("word", node)
                     .WithParams(myDictionary)
                     .Return(word => word.As<Word>())
                     .Results;

                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
       
        public Word InsertNode2(Word myWord, Dictionary<string, object> myDictionary)
        {
            try
            {




                var results = client.Cypher
                     .Create("(word:Word {word})")
                     .WithParam("word", myWord)
                     .Return(word => word.As<Word>())
                     .Results;


                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        #endregion

        public bool exciteNode(NodeReferenceStats nRefS)
        {
            throw new NotImplementedException();
        }

    }
}
