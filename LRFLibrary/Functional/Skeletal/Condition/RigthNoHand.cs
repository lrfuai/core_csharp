using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class RigthNoHand : ISkeltalCondition
    {
        bool ISkeltalCondition.apply(Microsoft.Kinect.Skeleton skel)
        {
            Joint rigthHand = skel.Joints[JointType.HandRight];
            return rigthHand.TrackingState.Equals(JointTrackingState.Inferred);
        }
    }
}
