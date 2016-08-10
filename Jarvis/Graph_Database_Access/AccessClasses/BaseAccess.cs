using Neo4jClient;
using Net.Graph.Neo4JD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Database_Access.AccessClasses
{
    public abstract class BaseAccess<T> where T:BusinessObjects.BOBase
    {
        private  GraphClient _client;
        public virtual GraphClient client
        {
            get
            {
                if (_client == null)
                {
                    _client = new GraphClient(new Uri("http://localhost:7474/db/data"));
                }
                if (!_client.IsConnected)
                    _client.Connect();
                return _client;

            }
           
        }

        public virtual bool exciteNode(NodeReference<T> nodeRef, int exitationAmount)
        {

            var myNode = client.Update(
                nodeRef,
                node =>
                {
                    node.currentExitation = node.currentExitation + exitationAmount;
                });
            if (myNode.Data.currentExitation >= myNode.Data.firePoint)
            {
                List<Node> myNodes = new List<Node>();

                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual List<Node> getChildNodes(NodeReference<T> nodeRef)
        {
            throw new NotImplementedException();
        }

        public virtual bool exciteNode(T node, int exitationAmount)
        {
            throw new NotImplementedException();
        }
        protected BaseAccess()
        {
        }
    }
}
