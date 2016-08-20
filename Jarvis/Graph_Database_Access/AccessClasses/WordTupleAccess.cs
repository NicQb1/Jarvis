using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Graph_Database_Access.BusinessObjects;

namespace Graph_Database_Access.AccessClasses
{

    public class WordTupleAccess : BaseAccess<WordTuple>, IGDBAccess<WordTuple>
    {
        public bool exciteNode(NodeReferenceStats nRefS)
        {
            throw new NotImplementedException();
        }

        public bool Exists(WordTuple node)
        {
            throw new NotImplementedException();
        }

        public WordTuple GetObjectClass(object value)
        {
            throw new NotImplementedException();
        }

        public WordTuple InsertNode(WordTuple node, Dictionary<string, object> myDictionary)
        {
            throw new NotImplementedException();
        }
    }
}
