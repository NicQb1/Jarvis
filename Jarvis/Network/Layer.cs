using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurons;

namespace Network
{
    public class Layer
    {
        public INeuron[][][] neuronLayer;
        public Layer(int x, int z, int t)
        {
            neuronLayer = new INeuron[x][][];
            for(int i = 0; i< z; i++)
            {
                neuronLayer[i]= new INeuron[i][];
                for (int b = 0; b < z; b++)
                {
                    neuronLayer[i][b] = new INeuron[b];

                }
            }
        }
    }

  


}
