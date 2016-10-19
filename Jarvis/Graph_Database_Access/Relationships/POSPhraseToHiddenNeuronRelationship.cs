using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.Relationships
{
 
   public class POSPhraseToHiddenNeuronRelationship : Relationship,
     IRelationshipAllowingSourceNode<POSPhrase>,
     IRelationshipAllowingTargetNode<HiddenNeuron>
    {

        public const string TypeKey = "POSPhrase To HiddenNeuron Rel";

        public POSPhraseToHiddenNeuronRelationship(NodeReference targetNode) : base(targetNode)
        {
        }



        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
