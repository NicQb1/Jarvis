using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.Relationships
{
  
    public class WordToPOSRelationship : Relationship,
     IRelationshipAllowingSourceNode<Word>,
     IRelationshipAllowingTargetNode<Definition>
    {

        public const string TypeKey = "Word_To_POS";

        public WordToPOSRelationship(NodeReference targetNode) : base(targetNode)
        {
        }



        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
