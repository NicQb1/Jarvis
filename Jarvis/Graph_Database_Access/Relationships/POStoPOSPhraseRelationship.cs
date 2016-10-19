using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.Relationships
{
  
    public class POStoPOSPhraseRelationship : Relationship,
     IRelationshipAllowingSourceNode<PartOfSpeech>,
     IRelationshipAllowingTargetNode<POSPhrase>
    {

        public const string TypeKey = "POS to POSPhrase Rel";

        public POStoPOSPhraseRelationship(NodeReference targetNode) : base(targetNode)
        {
        }



        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
