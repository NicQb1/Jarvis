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

    
     
        public SerialStreamingInput(ref global::Network.Matrix matrix)
        {
            this.matrix = matrix;
        }
    }
}
