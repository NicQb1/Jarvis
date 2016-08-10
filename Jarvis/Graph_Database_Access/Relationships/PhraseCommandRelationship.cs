using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.Relationships
{
    public class PhraseCommandRelationship : Relationship,
        IRelationshipAllowingSourceNode<Command>,
        IRelationshipAllowingTargetNode<Phrase>
    {

        public const string TypeKey = "Phrase_Means_Command";

        public PhraseCommandRelationship(NodeReference targetNode) : base(targetNode)
        {
        }



        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
