using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Common.enums;
using Common.structs;
using Neurons;
using Common.Classes;

namespace NNBuilder_Runable

{

   
    public class BuildMatrix
    {
        public Matrix matrix;
        public Int16 inputLayer;
        public Int16 x;
        public Int16 y;
        public Int16 z;
        public Int16 t;
        public Int16 byteSize;
        public Utilities utilities = new Utilities();
        public List<coordinates[]> inputBytes;
        public List<coordinates[]> outputBytes;
        public List<Methods> methods;
        public List<MethodsDefinitions> methodDefinitions;
        public Int16 maxNeuronDistance = 16;



        public Matrix Build_New_Matrix(Int16 _x, Int16 _y, Int16 _z, Int16 _t, Int16 _byteSize, Int16 InputLayer)
        {
            x = _x;
            y = _y;
            z = _z;
            t = _t;
            byteSize = _byteSize;
            inputLayer = InputLayer;
            buildInputLayer();
            buildMethodInputOutputPoints();


            return matrix;

        }

        private void buildInputLayerColumns(coordinates column)
        {
         
            for(Int16 i = inputLayer; i < y; i++)
            {
                if(i== y-1)
                {
                    buildOutPutPoint(column, neuronDirection.up, i);

                }else
                {
                    buildProcessingNeuron(column, neuronDirection.up, i);
                }
            }
            
            for (Int16 i = y; i >= 0; i--)
            {
                if (i == y - 1)
                {
                    buildOutPutPoint(column, neuronDirection.down, i);

                }
                else
                {
                    buildProcessingNeuron(column, neuronDirection.down, i);
                }
            }

            for (Int16 i = 0; i < inputLayer; i++)
            {
                if (i == y - 1)
                {
                    buildOutPutPoint(column, neuronDirection.up, i);

                }
                else
                {
                    buildProcessingNeuron(column, neuronDirection.up, i);
                }
            }
        }

        private void buildProcessingNeuron(coordinates column, neuronDirection direction, Int16 layer)
        {
            coordinates freeLocation = getClosestFreeSpace(column, layer);
            matrix.mainMatrix[freeLocation.y].neuronLayer[freeLocation.x][freeLocation.z][freeLocation.t] = new Neurons.NeuronExitor(direction, ref matrix);
 
            freeLocation = getClosestFreeSpace(freeLocation, layer);
            matrix.mainMatrix[freeLocation.y].neuronLayer[freeLocation.x][freeLocation.z][freeLocation.t] = new Neurons.NeuronInhibitor(direction, ref matrix);

            freeLocation = getClosestFreeSpace(freeLocation, layer);
            matrix.mainMatrix[freeLocation.y].neuronLayer[freeLocation.x][freeLocation.z][freeLocation.t] = new Neurons.NeuronExitor(direction, ref matrix);


        }

        private void buildOutPutPoint(coordinates column, neuronDirection direction, Int16 layer)
        {
            coordinates freeLocation = getClosestFreeSpace(column, layer);
            matrix.mainMatrix[freeLocation.y].neuronLayer[freeLocation.x][freeLocation.z][freeLocation.t] = new Neurons.NeuronOutput(ref matrix, direction);

            freeLocation = getClosestFreeSpace(column, layer);
            matrix.mainMatrix[freeLocation.y].neuronLayer[freeLocation.x][freeLocation.z][freeLocation.t] = new Neurons.NeuronPyramidal(ref matrix,direction);

            freeLocation = getClosestFreeSpace(column, layer);
            matrix.mainMatrix[freeLocation.y].neuronLayer[freeLocation.x][freeLocation.z][freeLocation.t] = new Neurons.NeuronTransfer(ref matrix, direction);


        }

        private coordinates getClosestFreeSpace(coordinates column, Int16 layer)
        {
            coordinates results = new coordinates();
            var currentLayer = matrix.mainMatrix[layer];
           
            Int16 i = 0;
            Int16 currentX =(Int16) column.x;
            Int16 currentZ = (Int16)column.z;
            var dir = direction.up;
            Int16 maxMove = 1;
            Int16 currentMovecount = 0;
            do
            {
               var currentSpace = currentLayer.neuronLayer[currentX][currentZ];
                for (Int16 t_space = 0; t_space < t; t_space++)
                {
                    if (currentSpace[t_space] == null)
                    {
                        results.t = t_space;
                        results.x = currentX;
                        results.y = layer;
                        results.z = currentZ;

                        return results;
                    }
                }
                if(dir == direction.up)
                {
                    currentX++;
                    currentMovecount++;
                }
                if(dir == direction.left)
                {
                    currentZ--;
                    currentMovecount++;
                }
                if (dir == direction.down)
                {
                    currentX--;
                    currentMovecount++;
                }
                if (dir == direction.right)
                {
                    currentZ++;
                    currentMovecount++;
                }

                if(currentMovecount == maxMove)
                {
                    currentMovecount = 0;
                    switch(dir)
                    {
                        case direction.up:
                            {
                                dir = direction.left;
                                break;
                            }
                        case direction.left:
                            {
                                maxMove++;
                                dir = direction.down;
                                break;

                            }
                        case direction.down:
                            {
                                maxMove++;
                                dir = direction.right;
                                break;
                            }
                        case direction.right:
                            {
                               
                                dir = direction.up;
                                break;
                            }
                        

                    }

                }

                if(currentX < 0 || currentX >= x || currentZ <0 || currentZ >= z)
                {
                    results.t = -1;
                    results.x = -1;
                    results.y = -1;
                    results.z = -1;
                    return results;
                }




                i++;
            } while (i < maxNeuronDistance);
              results.t = -1;
            results.x = -1;
            results.y = -1;
            results.z = -1;
            return results;
        }

        private void buildInputLayer()
        {
            List<PointF> inputNeuronLocations = utilities.getInputPoints(y, z, byteSize);
            inputBytes = new List<coordinates[]>();
           
            matrix = new Matrix();
            matrix.inputPoints = inputNeuronLocations;
            matrix.mainMatrix = new Layer[x];
            matrix.mainMatrix[inputLayer] = new Layer(y, z, t);
            coordinates[] tmpList = new coordinates[byteSize];
            Int16 bitcount = 0;
            foreach (PointF inploc in inputNeuronLocations)
            {

                if (matrix.mainMatrix[inputLayer].neuronLayer[(Int16)inploc.X] == null)
                {
                    matrix.mainMatrix[inputLayer].neuronLayer[(Int16)inploc.X] = new Neurons.INeuron[y][];
                }

                if (matrix.mainMatrix[inputLayer].neuronLayer[(Int16)inploc.X][(Int16)inploc.Y] == null)
                {
                    matrix.mainMatrix[inputLayer].neuronLayer[(Int16)inploc.X][(Int16)inploc.Y] = new Neurons.INeuron[t];
                }

                if (matrix.mainMatrix[inputLayer].neuronLayer[(Int16)inploc.X][(Int16)inploc.Y][0] == null)
                {
                    matrix.mainMatrix[inputLayer].neuronLayer[(Int16)inploc.X][(Int16)inploc.Y][0] = new Neurons.NeuronInput(ref matrix, neuronDirection.up);
                   
                    coordinates tmp = new coordinates();
                    tmp.y = inputLayer;
                    tmp.x = (Int16)inploc.X;
                    tmp.z = (Int16)inploc.Y;
                    tmp.t = 0;

                    buildInputLayerColumns(tmp);
                    tmpList[bitcount] = tmp;
                    if (bitcount == byteSize)
                    {
                        inputBytes.Add(tmpList);
                        bitcount = 0;
                        tmpList = new coordinates[byteSize];
                    }
                }

                bitcount++;
            }

        }

        private void buildMethodInputOutputPoints()
        {
            int currentInputLocation = 0;
            int currentInputLocation2 = 0;
            for (int i = 2; i < x - 2; i++)
            {
                for (int b = 2; b < x - b; i++)
                {
                    foreach (var c in methodDefinitions)
                    {
                        Methods myTempMethod = new Methods();
                      
                        coordinates[] co = inputBytes[currentInputLocation];
                        myTempMethod.fireNeuron = getClosestFreeSpace(co[currentInputLocation2], (Int16)i);
                        myTempMethod.readyNeuron = getClosestFreeSpace(co[currentInputLocation2], (Int16)i);

                        myTempMethod.inputBytes = new coordinates[c.inputBytesSize];
                        myTempMethod.outputBytes = new coordinates[c.outputBytesSize];
                        for (int d = 0; d< c.inputBytesSize; d++)
                        {
                            myTempMethod.inputBytes[d] = getClosestFreeSpace(co[currentInputLocation2], (Int16)i);

                        }
                        for (int d = 0; d < c.outputBytesSize; d++)
                        {
                            myTempMethod.outputBytes[d] = getClosestFreeSpace(co[currentInputLocation2], (Int16)i);
                        }

                    }
                    currentInputLocation2++;
                }
                    currentInputLocation++;
                
            }
           
        }

      
    }
}

