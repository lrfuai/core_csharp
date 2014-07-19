using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Logical.Arm
{
    public interface IArm
    {
        /*
        readonly byte MinWristValue;
        readonly byte MaxWristValue;

        readonly byte MinElbowValue;
        readonly byte MaxElbowValue;

        readonly byte MinBaseValue;
        readonly byte MaxBaseValue;

        readonly byte MinShoulderValue;
        readonly byte MaxShoulderValue;
        */
        void moveWristTo(Byte postition);
        void moveElbowTo(Byte postition);
        void moveBaseTo(Byte postition);
        void moveShoulderTo(Byte postition);
    }
}
