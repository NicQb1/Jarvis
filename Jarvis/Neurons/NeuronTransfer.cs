using Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons
{
    public class NeuronTransfer : NeuronBase
    {
        public NeuronTransfer(ref Matrix _matrix, neuronDirection nd) : base(ref _matrix, nd)
        {
            matrix = _matrix;
            Ndirection = nd;
        }
        public new NeuronTypeEnum GetType()
        {
            if (Ndirection == neuronDirection.up)
            {
                return NeuronTypeEnum.u_transfer;
            }
            else
                return NeuronTypeEnum.d_transfer;
        }
    }
}
