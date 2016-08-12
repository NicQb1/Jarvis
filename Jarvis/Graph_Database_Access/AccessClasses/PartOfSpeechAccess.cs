using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace Graph_Database_Access.AccessClasses
{
    public class PartOfSpeechAccess : BaseAccess<PartOfSpeech>, IGDBAccess<PartOfSpeech>
    {
        public PartOfSpeech GetObjectClass(object value)
        {
            var result = client.Cypher.Match("(partOfSpeech:PartOfSpeech)")
                 .Where((PartOfSpeech partOfSpeech) => partOfSpeech.pos == (string)value)
                 .Return(partOfSpeech => partOfSpeech.As<PartOfSpeech>())
                 .Results
                 .Single();
            return result;
        }

        public NodeReference<PartOfSpeech> InsertNode(PartOfSpeech node, Dictionary<string, object> myDictionary)
        {
            var myNodeReference = client.Create(node);

            return myNodeReference;
        }
    }
}
