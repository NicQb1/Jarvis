using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.enums;
using Common.structs;
using Common.Classes;

namespace Neurons
{
    public class NeuronBase : INeuron
    {
        public neuronDirection Ndirection;
        public NeuronTypeEnum MyType;
        public float exitationPoint;
        public float currentStatus;
        public Synapses[] synapses;
        public Matrix matrix;


        public NeuronBase(ref Matrix _matrix, neuronDirection nd)
        {
            matrix = _matrix;
            Ndirection = nd;
        }
        public void reset()
        {
            currentStatus = 0;
        }
        public void fire()
        {
            matrix.Activate(synapses, currentStatus);
        }

        public void excite(float excitationValue)
        {
            currentStatus = currentStatus + excitationValue;
            if (currentStatus >= exitationPoint)
            {
                fire();
            }
        }


    }
}
