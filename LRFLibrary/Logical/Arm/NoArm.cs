using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Logical.Arm
{
    class NoArm : IArm
    {
        public void moveWristTo(float degree) {}
        public void moveElbowTo(float degree) { }
        public void moveBaseTo(float degree) { }
        public void moveShoulderTo(float degree) { }
    }
}
