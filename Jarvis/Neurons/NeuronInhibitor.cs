using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.enums;

namespace Neurons
{
    public class NeuronInhibitor : NeuronBase
    {
        private neuronDirection direction;

       

        public NeuronInhibitor(neuronDirection nd, ref Matrix _matrix) :base( nd, ref _matrix)
        {
            this.Ndirection = nd;
        }
        public new NeuronTypeEnum GetType()
        {
            if (Ndirection == neuronDirection.up)
            {
                return NeuronTypeEnum.u_inhibitor;
            }
            else
                return NeuronTypeEnum.d_inhibitor;
        }
    }
}
