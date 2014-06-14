using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Logical.Arm
{
    public interface IArm
    {
        void moveWristTo(Byte postition);
        void moveElbowTo(Byte postition);
        void moveBaseTo(Byte postition);
        void moveShoulderTo(Byte postition);
    }
}
