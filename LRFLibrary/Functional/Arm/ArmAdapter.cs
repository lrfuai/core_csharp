using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LRFLibrary.Logical.Arm;

namespace LRFLibrary.Functional.Arm
{
    class ArmAdapter : IArm
    {
        Logical.Arm.IArm logicalArm;

        public ArmAdapter(Logical.Arm.IArm logicalArm)
        {
            this.logicalArm = logicalArm;
        }

        public void moveWristTo(float angle)
        {
            //this.moveWristTo();
        }

        public void moveElbowTo(float angle)
        {
            //this.moveElbowTo();
        }

        public void moveBaseTo(float angle)
        {
            //this.moveBaseTo();
        }

        public void moveShoulderTo(float angle)
        {
            //this.moveShoulderTo();
        }
    }
}
