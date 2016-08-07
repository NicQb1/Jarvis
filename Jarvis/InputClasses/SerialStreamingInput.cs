using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputClasses
{
    public class SerialStreamingInput : IInput
    {
        private global::Network.Matrix matrix;
        private Utilities _utilities = new Utilities();
        private Int16 bitSize = 8;

        public SerialStreamingInput(ref global::Network.Matrix matrix)
        {
            this.matrix = matrix;
        }

        public void set_InputLocations(object myData)
        {
            throw new NotImplementedException();
        }
    }
}
