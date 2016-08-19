using Graph_Database_Access.AccessClasses;
using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access
{
    public class InputLogic
    {

        public void InputPhrase(string phrase)
        {
            string[] words = phrase.Split(' ');
            InsertPhrase(phrase);

        }

        public Node<Phrase> InsertPhrase(string phrase)
        {
            var phr = new Phrase();
            phr.phrase = phrase;
            PhraseAccess pa = new PhraseAccess();
            var phraseList = pa.getMatchingNodes(phr);
            if (phraseList.Count == 0)
            {
                NodeReference<Phrase> nr = pa.InsertNodeGetRef(phr, new Dictionary<string, object>());

                return pa.client.Get(nr);
            }
            return null;

        }
    }
}
