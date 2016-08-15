using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace Graph_Database_Access.AccessClasses
{
    public class POSPhraseAccess : BaseAccess<POSPhrase>, IGDBAccess<POSPhrase>
    {
        public List<PartOfSpeech> GetPosPhrase(Phrase myPhrase)
        {
            List<PartOfSpeech> results = new List<PartOfSpeech>();
            string[] words = myPhrase.phrase.Split(' ');
            foreach (string word in words)
            {
                WordAccess wa = new WordAccess();
                PartOfSpeech pos = wa.GetPartOfSpeech(word);
                results.Add(pos);
            }
            return results;

        }
        public POSPhrase GetObjectClass(object value)
        {
            var result =
            client.Cypher.Match("(phrase:POSPhrase)")
                .Where((POSPhrase phrase) => phrase.grammarPhraseString== (string)value)
                .Return(phrase => phrase.As<POSPhrase>())
                .Results
                .Single();
            return result;
        }

        public bool Exists(POSPhrase node)
        {

            return client.Cypher.Match("(phrase:POSPhrase)")
                 .Where((POSPhrase phrase) => phrase.grammarPhraseString == node.grammarPhraseString)
                 .Return(phrase => phrase.As<POSPhrase>())
                 .Results
                 .Any();

        }


    }
}
