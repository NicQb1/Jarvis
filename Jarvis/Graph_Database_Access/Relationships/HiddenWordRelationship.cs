using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.Relationships
{
   
        public class HiddenWordRelationship : Relationship,
     IRelationshipAllowingSourceNode<Word>,
     IRelationshipAllowingTargetNode<HiddenNeuron>
        {

            public const string TypeKey = "Word_Hidden_Rel";

            public HiddenWordRelationship(NodeReference targetNode) : base(targetNode)
            {
            }



            public override string RelationshipTypeKey
            {
                get { return TypeKey; }
            }
        }
    
}
