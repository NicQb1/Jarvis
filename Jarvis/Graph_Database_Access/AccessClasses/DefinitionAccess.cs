using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;

namespace Graph_Database_Access.AccessClasses
{
    public class DefinitionAccess : BaseAccess<Definition>, IGDBAccess<Definition>
    {
        public Definition GetObjectClass(object value)
        {
            var result = client.Cypher.Match("(definition:Definition)")
                 .Where((Definition definition) => definition.definition == (string)value)
                 .Return(definition => definition.As<Definition>())
                 .Results
                 .Single();
            return result;
        }

        public NodeReference<Definition> InsertNode(Definition node, Dictionary<string, object> myDictionary)
        {
            var myNodeReference = client.Create(node);
         
            return myNodeReference;
        }
    }
}
