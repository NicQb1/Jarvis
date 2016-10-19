using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTO;
using Graph_Database_Access.BusinessObjects;
using Neo4jClient;

namespace Graph_Database_Access.AccessClasses
{

    public class TupleRefAccess : BaseAccess<TupleRef>, IGDBAccess<TupleRef>
    {
        public bool exciteNode(NodeReference<TupleRef> nRefS)
        {
            throw new NotImplementedException();
        }

        public bool exciteNode(NodeReferenceStats nRefS)
        {
            throw new NotImplementedException();
        }

        public bool Exists(TupleRef node)
        {
            throw new NotImplementedException();
        }

        public TupleRef GetObjectClass(object value)
        {
            throw new NotImplementedException();
        }

        public TupleRef InsertNode(TupleRef node, Dictionary<string, object> myDictionary)
        {
            throw new NotImplementedException();
        }
    }
}
