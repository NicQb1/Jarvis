using Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons
{
   public  class NeuronSync : NeuronBase
    {
        public NeuronSync(ref Matrix _matrix, neuronDirection nd) : base(nd, ref _matrix)
        {
            matrix = _matrix;
            Ndirection = nd;
        }
    }
   
}
