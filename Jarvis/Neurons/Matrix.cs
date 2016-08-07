using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Common.structs;

namespace Neurons
{
    public class Matrix
    {
        public List<PointF> inputPoints; 
        public Layer[] mainMatrix;
        public Layer inputLayer;
        public Matrix()
        {

        }
        public Matrix(Int16 y, Int16 x, Int16 z, Int16 t)
        {
            mainMatrix = new Layer[y];
            for (Int16 i = 0; i < y; i++)
            {
                mainMatrix[i] = new Layer(x, z, t);
            }
        }

        public void SpeechInput(string text)
        {
            char[] myCharArray = text.ToCharArray();

            foreach(char myChar in myCharArray)
            {
                byte[] myByteArray = BitConverter.GetBytes(myChar);
                for(Int16 i =0; i < inputPoints.Count; i++)
                {
                    inputLayer.SendInByte( myByteArray[i]);

                }

            }
           
        }

        internal void Activate(Synapses[] synapses, float coefficient)
        {
            foreach(Synapses s in synapses)
            {
                mainMatrix[s.neuronPlaces.x].neuronLayer[s.neuronPlaces.y][s.neuronPlaces.z][s.neuronPlaces.t].excite(s.weightCoeficient * coefficient);
            }

          
        }
    }
}
