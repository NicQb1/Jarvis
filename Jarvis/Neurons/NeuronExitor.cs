using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.enums;

namespace Neurons
{
    public class NeuronExitor : NeuronBase
    {
        private neuronDirection direction;

       
        public NeuronExitor(neuronDirection nd, ref Matrix _matrix) :base( nd, ref _matrix)
        {
            this.Ndirection = nd;
        }
        public new NeuronTypeEnum GetType()
        {
            if (Ndirection == neuronDirection.up)
            {
                return NeuronTypeEnum.u_exitor;
            }
            else
                return NeuronTypeEnum.d_exitor;
        }
    }
}
