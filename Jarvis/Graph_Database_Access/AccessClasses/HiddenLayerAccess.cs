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
    public class HiddenLayerAccess : BaseAccess<HiddenNeuron>, IGDBAccess<HiddenNeuron>
    {
        public bool exciteNode(NodeReferenceStats nRefS)
        {
            throw new NotImplementedException();
        }

        public bool exciteNode(NodeReference<HiddenNeuron> nRefS)
        {
            throw new NotImplementedException();
        }

        public bool Exists(HiddenNeuron node)
        {
            throw new NotImplementedException();
        }

        public HiddenNeuron GetObjectClass(object value)
        {
            throw new NotImplementedException();
        }

        public HiddenNeuron InsertNode(HiddenNeuron node, Dictionary<string, object> myDictionary)
        {
            throw new NotImplementedException();
        }

        internal void CreateHideenLayerWordRelationship(NodeReference<Word> wordRef)
        {
            throw new NotImplementedException();
        }
    }
}
