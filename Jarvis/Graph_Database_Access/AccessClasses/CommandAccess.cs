using Graph_Database_Access.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4jClient;
using Graph_Database_Access.Relationships;
using Net.Graph.Neo4JD;

namespace Graph_Database_Access.AccessClasses
{
    public class CommandAccess : BaseAccess<Command>, IGDBAccess<Command>
    {
       

        public Command GetObjectClass(object value)
        {
            var result =client.Cypher.Match("(command:Command)")
                  .Where((Command command) => command.name == (string)value)
                  .Return(command => command.As<Command>())
                  .Results
                  .Single();
            return result;
        }

        public NodeReference<Command> InsertNode(Command myCommand, Dictionary<string, object> myDictionary)
        {
            var myNodeReference = client.Create(myCommand);
            PhraseAccess pa = new PhraseAccess();
            var phrasenode = pa.InsertNode(pa.GetObjectClass(myCommand.phrase), myDictionary);
            AddEdge(myNodeReference.Id, PhraseCommandRelationship.TypeKey, phrasenode.Id, myDictionary);
            //RelationshipReference rr = client.CreateRelationship((NodeReference<Command>)myNodeReference, new PhraseCommandRelationship(phrasenode));
           
            
            return myNodeReference;
        }
        
    }
}
