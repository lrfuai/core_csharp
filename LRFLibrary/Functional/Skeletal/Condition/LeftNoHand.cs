using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class LeftNoHand : ISkeltalCondition
    {
        bool ISkeltalCondition.apply(Microsoft.Kinect.Skeleton skel)
        {
            Joint leftHand = skel.Joints[JointType.HandLeft];
            return leftHand.TrackingState.Equals(JointTrackingState.Inferred);
        }
    }
}
