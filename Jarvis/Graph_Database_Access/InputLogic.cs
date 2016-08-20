using Common.DTO;
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


        public string updateStatsFireNodes(List<NodeReferenceStats> phRefs)
        {
            foreach (var phRef in phRefs)
            {
                switch (phRef.type)
                {
                    case "Word":
                        WordAccess wa = new WordAccess();
                        wa.exciteNode(phRef);
                        
                        break;
                    case "WordTuple":
                        WordTupleAccess wt = new WordTupleAccess();
                        wt.exciteNode(phRef);
                       
                        break;
                    case "Phrase":
                        PhraseAccess pa = new PhraseAccess();
                        pa.exciteNode(phRef);
                      
                        break;
                    case "TupleRef":
                        TupleRefAccess ta = new TupleRefAccess();
                        ta.exciteNode(phRef);
                        break;
                    default:
                        throw new NotImplementedException();

                }
            }

            return pollResponse();


        }

        private string pollResponse()
        {
            throw new NotImplementedException();
        }
    }
}
