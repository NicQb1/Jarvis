using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using Common.DTO;

namespace Graph_Database_Access.AccessClasses
{
    public class DefinitionAccess : BaseAccess<Definition>, IGDBAccess<Definition>
    {
        public Definition GetObjectClass(object value)
        {
            var result = client.Cypher.Match("(definition:Definition)")
                 .Where(" definition.definition = '" + value + "'")
                 .Return(definition => definition.As<Definition>())
                 .Results
                 .Single();
            return result;
        }

        public NodeReference<Definition> InsertNodeGetReference(Definition node, Dictionary<string, object> myDictionary)
        {
            var myNodeReference = client.Create(node);
            try
            {

                var results = client.Cypher
                     .Create("(definition:Definition {definition})")
                     .WithParam("definition", node)
                     .Return(definition => definition.As<Definition>())
                     .Results;
                var x = client.Get<Definition>((NodeReference)results.First().Id);


                return x.Reference;
            }
            catch (Exception ex)
            {
                return null;
            }
            return myNodeReference;
        }

        public Definition InsertNode(Definition node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(definition:Definition {definition})")
                     .WithParam("definition", node)
                     .Return(definition => definition.As<Definition>())
                     .Results;

                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
       
        public bool Exists(Definition node)
        {

            return client.Cypher.Match("(definition:Definition)")
                 .Where(" definition.definition = '" + node.definition + "'")
                 .Return(definition => definition.As<Definition>())
                 .Results
                 .Any();

        }

        public bool exciteNode(NodeReferenceStats nRefS)
        {
            throw new NotImplementedException();
        }
    }
}
