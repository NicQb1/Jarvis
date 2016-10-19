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
    public class OutputNodeAccess : BaseAccess<OutputNode>, IGDBAccess<OutputNode>
    {
        public bool exciteNode(NodeReference<OutputNode> nRefS)
        {
            throw new NotImplementedException();
        }

        public bool Exists(OutputNode node)
        {
            throw new NotImplementedException();
        }

        public OutputNode GetObjectClass(object value)
        {
            throw new NotImplementedException();
        }

        public OutputNode InsertNode(OutputNode node, Dictionary<string, object> myDictionary)
        {
            throw new NotImplementedException();
        }
        public NodeReference<OutputNode> getOutputNodeByID(int opnID)
        {

            try
            {
                var results = client.Cypher
              .Match("(opn:OutputNode)")
              .Where(" opn.Id = " + opnID.ToString())
              .Return<Node<OutputNode>>("opn")
              .Results
              .Single();
              
                return results.Reference;
            }
            catch (Exception ex)
            { return null; }
        }

        internal void CreateHiddenNeuronOutputLayerRelationship(NodeReference<HiddenNeuron> hnRef1, NodeReference<HiddenNeuron> hnRef2)
        {
            throw new NotImplementedException();
        }

        public bool exciteNode(NodeReferenceStats nRefS)
        {
            throw new NotImplementedException();
        }
    }
}
