using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.enums
{
    public enum InputLayerTypeEnum
    {
       serial = 0,
       matrix =1,
       parallel=2,
       equalDistribution=3
    }

    public enum NeuronTypeEnum
    {
        u_exitor=0,
        u_inhibitor=1,
        u_outPut=2,
        u_pyramidial=3,
        u_transfer=4,
        u_timing_pulser=5,
        u_timing_accumulator=6,
        d_exitor=7,
        d_inhibitor=8,
        d_pyramidial=9,
        d_transfer=10,
        d_timing_pulser = 11,
        d_timing_accumulator = 12,
        u_inPut = 13,
        d_Output = 14
    }

    public enum neuronDirection
    {
        up =0,
        down =1
    }
    public enum direction
    {
        up=0,
        left=1,
        down=2,
        right=3
    }
}
