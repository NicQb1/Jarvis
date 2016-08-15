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
                     .Where((Word word) => word.word == node.word)
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
                var results = client.Cypher.Match("(word:Word)")
               .Where((Word word) => word.word == node.word)
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
                  .Where((Word word) => word.word == (string)value)
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

            return client.Cypher.Match("(word:Word)")
                 .Where((Word word) => word.word == node.word)
                 .Return(word => word.As<Word>())
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
                     .Return(word => word.As<Word>())
                     .Results;

                return results;
            }catch(Exception ex)
            {
                return null;
            }

        }
        public  Node<Word> InsertNode5(Word myWord, Dictionary<string, object> myDictionary)
        {


            var results =client.Cypher
                .Merge("(word:Word {Id: {myWord2}.Id })")
                .OnCreate()
                .Set("word = {myWord2}")
                .WithParams(
                            new
                            {
                                myWord2 =
                                        new Word()
                                        {
                                            word = myWord.word,
                                            pr = myWord.pr,
                                            hw = myWord.hw,
                                            firePoint = myWord.firePoint,
                                            currentExitation = 0
                                        }
                            })
                            .Return(word => word.As<Word>())
                     .Results;

            // var myNodeReference = client.Create(myWord);
            return client.Get<Word>((NodeReference<Word>)results.First().Id);
           // return results;

        }
        public NodeReference<Word> InsertNode2(Word myWord, Dictionary<string, object> myDictionary)
        {

            var myNodeReference = client.Create(myWord);
            return myNodeReference;

        }
        #endregion


    }
}
