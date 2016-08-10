
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph_Database_Access.BusinessObjects;


namespace Graph_Database_Access.Relationships
{
    public class WordToWordRelationship : Relationship,
        IRelationshipAllowingSourceNode<Word>,
        IRelationshipAllowingTargetNode<Word>
    {

        public const string TypeKey = "Word_To_Word";

        public WordToWordRelationship(NodeReference targetNode) : base(targetNode)
        {
        }


       
        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
