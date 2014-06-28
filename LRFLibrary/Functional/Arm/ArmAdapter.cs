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
        byte algo = 1;

        public ArmAdapter(Logical.Arm.IArm logicalArm)
        {
            this.logicalArm = logicalArm;
        }

        public void moveWristTo(float angle)
        {
            this.logicalArm.moveWristTo(algo);
        }

        public void moveElbowTo(float angle)
        {
            this.logicalArm.moveElbowTo(algo);
        }

        public void moveBaseTo(float angle)
        {
            this.logicalArm.moveBaseTo(algo);
        }

        public void moveShoulderTo(float angle)
        {
            this.logicalArm.moveShoulderTo(algo);
        }
    }
}
