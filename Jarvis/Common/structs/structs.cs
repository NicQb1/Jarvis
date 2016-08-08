using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.structs
{
    public struct coordinates
    {
        public Int16 x;
        public Int16 y;
        public Int16 z;
        public Int16 t;
    }

    public struct Methods
    {
        public coordinates[] inputBytes;
        public coordinates[] outputBytes;
        public string methodName;
        public coordinates fireNeuron;
        public coordinates readyNeuron;

    }

    public struct MethodsDefinitions
    {
        public int inputBytesSize;
        public int outputBytesSize;
        public string methodName;
       

    }

    public struct Synapses
    {
        public coordinates neuronPlaces;
        public float weightCoeficient;
    }
}
