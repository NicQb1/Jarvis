using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public class Matrix
    {

        public Layer[] mainMatrix;
        public Matrix(int y, int x, int z, int t)
        {
            mainMatrix = new Layer[y];
            for (int i = 0; i < y; i++)
            {
                mainMatrix[i] = new Layer(x, z, t);
            }
        }
    }
}
