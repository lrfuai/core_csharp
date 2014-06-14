using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Arm
{
    public interface IArm
    {
        void moveWristTo(float angle);
        void moveElbowTo(float angle);
        void moveBaseTo(float angle);
        void moveShoulderTo(float angle);
    }
}
