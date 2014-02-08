using Microsoft.Kinect;

namespace LRFLibrary.Functional.Skeletal.Condition
{
    public class TwoHandsUp : ISkeltalCondition
    {
        public bool apply(Skeleton skel)
        {
            Joint reference = skel.Joints[JointType.ShoulderCenter];
            Joint leftHand = skel.Joints[JointType.HandLeft];
            Joint rigthHand = skel.Joints[JointType.HandRight];

            if (!reference.TrackingState.Equals(JointTrackingState.Tracked) ||
                 ! leftHand.TrackingState.Equals (JointTrackingState.Tracked) ||
                 ! rigthHand.TrackingState.Equals(JointTrackingState.Tracked)
                )
            {
                return false;
            }

            return reference.Position.Y < leftHand.Position.Y && reference.Position.Y < rigthHand.Position.Y;
        }
    }
}
