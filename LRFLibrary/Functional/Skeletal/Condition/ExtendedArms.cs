using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class ExtendedArms : ISkeltalCondition
    {
        bool ISkeltalCondition.apply(Microsoft.Kinect.Skeleton skel)
        {
            Joint head = skel.Joints[JointType.Head];
            Joint leftHand = skel.Joints[JointType.HandLeft];
            Joint rigthHand = skel.Joints[JointType.HandRight];
            Joint shoulder = skel.Joints[JointType.ShoulderCenter];

            if (!head.TrackingState.Equals(JointTrackingState.Tracked) ||
                 !leftHand.TrackingState.Equals(JointTrackingState.Tracked) ||
                 !rigthHand.TrackingState.Equals(JointTrackingState.Tracked)
                )
            {
                return false;
            }

            return (head.Position.X > leftHand.Position.X && head.Position.X < rigthHand.Position.X) &&
                    (head.Position.Y > leftHand.Position.Y && head.Position.Y > rigthHand.Position.Y) &&
                    (shoulder.Position.Y < leftHand.Position.Y && shoulder.Position.Y < rigthHand.Position.Y);
        }

    }
}
