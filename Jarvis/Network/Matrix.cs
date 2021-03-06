﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Network
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
    }
}
