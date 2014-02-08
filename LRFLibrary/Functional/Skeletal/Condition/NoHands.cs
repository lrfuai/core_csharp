using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class NoHands : ISkeltalCondition
    {
        
        bool ISkeltalCondition.apply(Microsoft.Kinect.Skeleton skel)
        {
            Joint leftHand = skel.Joints[JointType.HandLeft];
            Joint rigthHand = skel.Joints[JointType.HandRight];

            if (leftHand.TrackingState.Equals(JointTrackingState.Inferred) && 
                rigthHand.TrackingState.Equals(JointTrackingState.Inferred))
            {
                return true;
            }
            return false;
        }
    }
}
