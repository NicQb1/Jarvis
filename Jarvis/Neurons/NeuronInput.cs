﻿using Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neurons
{
    public class NeuronInput : NeuronBase
    {
        public NeuronInput(ref Matrix _matrix, neuronDirection nd) : base(ref _matrix, nd)
        {
            matrix = _matrix;
            Ndirection = nd;
        }
    }
}
