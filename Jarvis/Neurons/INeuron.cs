using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.enums;

namespace Neurons
{
    public interface INeuron
    {

        void fire();

        void reset();

        void excite(float excitationValue);

        neuronDirection getDirection();



    }
}

