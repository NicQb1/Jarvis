using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neurons;

namespace Neurons
{
    public class Layer
    {
        public INeuron[][][] neuronLayer;

        public Layer(Int16 x, Int16 z, Int16 t)
        {
            neuronLayer = new INeuron[x][][];
            for(Int16 i = 0; i< z; i++)
            {
                neuronLayer[i]= new INeuron[i][];
                for (Int16 b = 0; b < t; b++)
                {
                    neuronLayer[i][b] = new INeuron[b];

                }
            }
        }

        internal void SendInByte(byte v)
        {
            
            throw new NotImplementedException();
        }
    }

  


}
