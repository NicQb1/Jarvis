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
                  .Where(" command.name = '" + value+ "'")
                  .Return(command => command.As<Command>())
                  .Results
                  .Single();
            return result;
        }

        public NodeReference<Command> InsertNodeGetRef(Command myCommand, Dictionary<string, object> myDictionary)
        {
            var myNode = CreateNode(myCommand, new Dictionary<string, object>());
            var myNodeReference = client.Get<NodeReference<Command>>((NodeReference < Command >) myNode.Id);
        
            PhraseAccess pa = new PhraseAccess();
            var phrasenode = client.Create(new Command { name = myCommand.name });

            AddEdge(myNodeReference.Data.Id, PhraseCommandRelationship.TypeKey, phrasenode.Id, myDictionary);
            //RelationshipReference rr = client.CreateRelationship((NodeReference<Command>)myNodeReference, new PhraseCommandRelationship(phrasenode));
           
            
            return myNodeReference.Data;
        }

        public Command InsertNode(Command myCommand, Dictionary<string, object> myDictionary)
        {
            var myNode = CreateNode(myCommand, new Dictionary<string, object>());
            var myNodeReference = client.Get<NodeReference<Command>>((NodeReference<Command>)myNode.Id);

            PhraseAccess pa = new PhraseAccess();
            var phrasenode = client.Create(new Command { name = myCommand.name });

            AddEdge(myNodeReference.Data.Id, PhraseCommandRelationship.TypeKey, phrasenode.Id, myDictionary);
            //RelationshipReference rr = client.CreateRelationship((NodeReference<Command>)myNodeReference, new PhraseCommandRelationship(phrasenode));


            return myNode;
        }

        public virtual Command CreateNode(Command node, Dictionary<string, object> myDictionary)
        {
            try
            {

                var results = client.Cypher
                     .Create("(command:Command {command})")
                     .WithParam("command", node)
                     .Return(command => command.As<Command>())
                     .Results;

                return results.First();
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool Exists(Command node)
        {

            return client.Cypher.Match("(command:Command)")
                 .Where(" command.name = '" + node.name + "'")
                 .Return(command => command.As<Command>())
                 .Results
                 .Any();

        }
        

    }
}
