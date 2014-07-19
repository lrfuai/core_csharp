using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using Microsoft.Xna.Framework;

namespace LRFLibrary.Functional.Modules
{
    using Arm;
    using LRFLibrary.Functional.Skeletal.Tracking;

    public class ArmHandlerModule : IModule
    {
        private SkeletalSelector _selector;
        private IArm _arm;

        public ArmHandlerModule(SkeletalSelector selector, IArm arm)
        {
            this._arm = arm;
            this._selector = selector;
        }
        
        public static float AngleBetweenTwoVectors(Vector3 vectorA, Vector3 vectorB)
        {
            float dotProduct = 0.0f;
            dotProduct = Vector3.Dot(vectorA, vectorB) / (vectorA.Length() * vectorB.Length());
            float result = MathHelper.ToDegrees((float) Math.Acos(dotProduct));
            return result;
        }

        void _selector_onSkeletonUpdated(object sender, SkeletalSelector.SkeletonArgs e)
        {
            Vector3 hand = new Vector3(
                e.Skeleton.Joints[JointType.HandRight].Position.X,
                e.Skeleton.Joints[JointType.HandRight].Position.Y,
                e.Skeleton.Joints[JointType.HandRight].Position.Z
            );

            Vector3 wrist = new Vector3(
                e.Skeleton.Joints[JointType.WristRight].Position.X,
                e.Skeleton.Joints[JointType.WristRight].Position.Y,
                e.Skeleton.Joints[JointType.WristRight].Position.Z
            );

            Vector3 elbow = new Vector3(
                e.Skeleton.Joints[JointType.ElbowRight].Position.X,
                e.Skeleton.Joints[JointType.ElbowRight].Position.Y,
                e.Skeleton.Joints[JointType.ElbowRight].Position.Z
            );

            Vector3 shoulder = new Vector3(
                e.Skeleton.Joints[JointType.ShoulderRight].Position.X,
                e.Skeleton.Joints[JointType.ShoulderRight].Position.Y,
                e.Skeleton.Joints[JointType.ShoulderRight].Position.Z
            );

            this._arm.moveWristTo(AngleBetweenTwoVectors( hand - wrist, elbow - wrist ));
            this._arm.moveElbowTo(AngleBetweenTwoVectors( wrist - elbow, shoulder - elbow ));
            /*
            this._arm.moveElbowTo(AngleBetweenTwoVectors(, b2));
            this._arm.moveElbowTo(AngleBetweenTwoVectors(b1, b2));
            */
            
        }

        public void run()
        {
            this._selector.Enable();
            this._selector.onSkeletonUpdated += _selector_onSkeletonUpdated;
        }

        public void stop()
        {
            this._selector.onSkeletonUpdated -= _selector_onSkeletonUpdated;
            this._selector.Disable();
        }
    }
}