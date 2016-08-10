using Graph_Database_Access.BusinessObjects;
using Neo4jClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Graph_Database_Access.Relationships
{
    public class WordPhraseRelationship : Relationship,
        IRelationshipAllowingSourceNode<Phrase>,
        IRelationshipAllowingTargetNode<Word>
    {

        public const string TypeKey = "Word_Is_In_Phrase";

        public  WordPhraseRelationship(NodeReference targetNode) : base(targetNode)
        {
        }



        public override string RelationshipTypeKey
        {
            get { return TypeKey; }
        }
    }
}
