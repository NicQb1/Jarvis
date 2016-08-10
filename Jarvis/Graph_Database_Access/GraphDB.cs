using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver.V1;
using Neurons;
using Net.Graph;
using Net.Graph.Neo4JD;
using Neo4jClient;
using Graph_Database_Access.Relationships;
using Graph_Database_Access.BusinessObjects;

namespace Graph_Database_Access
{
    public class GraphDB
    {
       

     

       
       public void fireNode(INeuron myNeuron)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"));
           client.Connect();
           
        }
    }
}
