using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Logical.Arm
{
    class NoArm : IArm
    {
        public void moveWristTo(byte postition) {}
        public void moveElbowTo(byte postition) {}
        public void moveBaseTo(byte postition) {}
        public void moveShoulderTo(byte postition) {}
    }
}
