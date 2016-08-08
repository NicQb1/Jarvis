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

namespace Graph_Database_Access
{
    public class GraphDB
    {
       

        public void InsertNode(INeuron myNeuron)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"));
           client.Connect();
            switch(myNeuron.GetType().Name)
            {
                case "Neurons.NeuronExitor":
                    var refA = client.Create(new NeuronExitor() { Direction = myNeuron. });
            }
           
        }

       public void fireNode(INeuron myNeuron)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"));
           client.Connect();
           
        }
    }
}
