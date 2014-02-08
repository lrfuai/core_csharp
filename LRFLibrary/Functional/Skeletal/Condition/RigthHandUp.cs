using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class RigthHandUp : ISkeltalCondition
    {
        bool ISkeltalCondition.apply(Microsoft.Kinect.Skeleton skel)
        {
            Joint reference = skel.Joints[JointType.ShoulderCenter];
            Joint rigthHand = skel.Joints[JointType.HandRight];

            if (!reference.TrackingState.Equals(JointTrackingState.Tracked) ||
                 !rigthHand.TrackingState.Equals(JointTrackingState.Tracked)
                )
            {
                return false;
            }

            return (reference.Position.Y < rigthHand.Position.Y);   
        }
    }
}
