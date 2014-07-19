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
            this.logicalArm.moveWristTo((byte)angle);
        }

        public void moveElbowTo(float angle)
        {
            this.logicalArm.moveElbowTo((byte)angle);
        }

        public void moveBaseTo(float angle)
        {
            this.logicalArm.moveBaseTo((byte)angle);
        }

        public void moveShoulderTo(float angle)
        {
            this.logicalArm.moveShoulderTo((byte)angle);
        }
    }
}
