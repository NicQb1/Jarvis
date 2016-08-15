using Neo4jClient;
using Net.Graph.Neo4JD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.AccessClasses
{
    public interface IGDBAccess<Tout> where Tout : class
    {
        Node<Tout> InsertNode(Tout node, Dictionary<string,object> myDictionary);

       

        Tout GetObjectClass(object value);

        bool exciteNode(Tout node, int exitationAmoun);

        bool exciteNode(NodeReference<Tout> nodeRef, int exitationAmoun);

        List<Node> getChildNodes(NodeReference<Tout> nodeRef);

        bool Exists(Tout node);


    }
        
        
}
