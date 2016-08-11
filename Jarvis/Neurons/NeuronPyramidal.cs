using Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons
{
    public class NeuronPyramidal : NeuronBase
    {

        public NeuronPyramidal(ref Matrix _matrix, neuronDirection nd) : base(nd, ref _matrix)
        {
            matrix = _matrix;
            Ndirection = nd;
        }
        public new NeuronTypeEnum GetType()
        {
            if (Ndirection == neuronDirection.up)
            {
                return NeuronTypeEnum.u_pyramidial;
            }
            else
                return NeuronTypeEnum.d_pyramidial;
        }
    }
}
