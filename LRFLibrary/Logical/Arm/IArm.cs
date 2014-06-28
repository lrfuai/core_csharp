using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Logical.Arm
{
    public interface IArm
    {
        void moveWristTo(float degree);
        void moveElbowTo(float degree);
        void moveBaseTo(float degree);
        void moveShoulderTo(float degree);
    }
}
