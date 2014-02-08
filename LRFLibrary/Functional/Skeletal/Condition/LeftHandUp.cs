using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class LeftHandUp : ISkeltalCondition
    {
        bool ISkeltalCondition.apply(Microsoft.Kinect.Skeleton skel)
        {
            Joint reference = skel.Joints[JointType.ShoulderCenter];
            Joint leftHand = skel.Joints[JointType.HandLeft];

            if (!reference.TrackingState.Equals(JointTrackingState.Tracked) ||
                 !leftHand.TrackingState.Equals(JointTrackingState.Tracked)
                )
            {
                return false;
            }

            return (reference.Position.Y < leftHand.Position.Y);
        }
    }
}
