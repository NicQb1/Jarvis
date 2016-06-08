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
        private global::Network.Matrix matrix1;
        private global::Network.Matrix matrix2;

        public SerialStreamingInput(ref global::Network.Matrix matrix2)
        {
            this.matrix2 = matrix2;
        }

        public SerialStreamingInput(ref global::Network.Matrix matrix1)
        {
            this.matrix1 = matrix1;
        }

        public SerialStreamingInput(ref global::Network.Matrix matrix)
        {
            this.matrix = matrix;
        }
    }
}
