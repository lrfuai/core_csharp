using System;
using System.Drawing;
using Microsoft.Kinect;

namespace LRFLibrary.Functional.Skeletal.Drawer
{
    class SkeletalDrawer : IDrawer
    {
        Pen inferredBonePen;
        Pen trackedBonePen;

        Brush trackedJointBrush;
        Brush inferredJointBrush;

        private const int JointThickness = 3;
        private const int BodyCenterThickness = 10;

        CoordinateMapper coordinateMapper;

        public SkeletalDrawer(CoordinateMapper coordinateMapper, Pen trackedBonePen, Pen inferredBonePen, Brush trackedJointBrush, Brush inferredJointBrush)
        {
            this.inferredBonePen = inferredBonePen;
            this.trackedBonePen = trackedBonePen;
            this.trackedJointBrush = trackedJointBrush;
            this.inferredJointBrush = inferredJointBrush;
            this.coordinateMapper = coordinateMapper;
        }

        public SkeletalDrawer(CoordinateMapper coordinateMapper)
        {
            this.trackedBonePen = new Pen(Brushes.Green, 6);
            this.inferredBonePen = new Pen(Brushes.Gray, 1);
            this.trackedJointBrush = Brushes.Red;
            this.inferredJointBrush = Brushes.Yellow;
            this.coordinateMapper = coordinateMapper;
        }

        public void draw(Graphics graphics, Skeleton skel)
        {
            // Torzo
            this.draw(graphics,skel,JointType.Head,JointType.ShoulderCenter);
            this.draw(graphics, skel, JointType.ShoulderCenter, JointType.ShoulderLeft);
            this.draw(graphics, skel, JointType.ShoulderCenter, JointType.ShoulderRight);
            this.draw(graphics, skel, JointType.ShoulderCenter, JointType.Spine);
            this.draw(graphics, skel, JointType.Spine, JointType.HipCenter);
            this.draw(graphics, skel, JointType.HipCenter, JointType.HipLeft);
            this.draw(graphics, skel, JointType.HipCenter, JointType.HipRight);

            // Left Arm
            this.draw(graphics, skel, JointType.ShoulderLeft, JointType.ElbowLeft);
            this.draw(graphics, skel, JointType.ElbowLeft, JointType.WristLeft);
            this.draw(graphics, skel, JointType.WristLeft, JointType.HandLeft);

            // Right Arm
            this.draw(graphics, skel, JointType.ShoulderRight, JointType.ElbowRight);
            this.draw(graphics, skel, JointType.ElbowRight, JointType.WristRight);
            this.draw(graphics, skel, JointType.WristRight, JointType.HandRight);

            // Left Leg
            this.draw(graphics, skel, JointType.HipLeft, JointType.KneeLeft);
            this.draw(graphics, skel, JointType.KneeLeft, JointType.AnkleLeft);
            this.draw(graphics, skel, JointType.AnkleLeft, JointType.FootLeft);

            // Right Arm
            this.draw(graphics, skel, JointType.HipRight, JointType.KneeRight);
            this.draw(graphics, skel, JointType.KneeRight, JointType.AnkleRight);
            this.draw(graphics, skel, JointType.AnkleRight, JointType.FootRight);

            // Render Joints
            foreach (Joint joint in skel.Joints)
            {
                this.draw(graphics, skel, joint.JointType);
            }
        }

        public void draw(Graphics graphics, Skeleton skel, JointType type)
        {
            Joint joint = skel.Joints[type];
            Brush drawBrush = null;

            if (joint.TrackingState == JointTrackingState.Tracked)
            {
                drawBrush = this.trackedJointBrush;
            }
            else if (joint.TrackingState == JointTrackingState.Inferred)
            {
                drawBrush = this.inferredJointBrush;
            }

            if (drawBrush != null)
            {
                Point position = this.SkeletonPointToScreen(joint.Position);
                graphics.DrawEllipse(new Pen(drawBrush), position.X, position.Y, JointThickness, JointThickness);
            }
        }

        public void draw(Graphics graphics, Skeleton skel, JointType typeOne, JointType typeTwo)
        {
            Joint joint0 = skel.Joints[typeOne];
            Joint joint1 = skel.Joints[typeTwo];

            // If we can't find either of these joints, exit
            if (joint0.TrackingState == JointTrackingState.NotTracked ||
                joint1.TrackingState == JointTrackingState.NotTracked)
            {
                return;
            }

            // Don't draw if both points are inferred
            if (joint0.TrackingState == JointTrackingState.Inferred &&
                joint1.TrackingState == JointTrackingState.Inferred)
            {
                return;
            }

            // We assume all drawn bones are inferred unless BOTH joints are tracked
            Pen drawPen = this.inferredBonePen;
            if (joint0.TrackingState == JointTrackingState.Tracked && joint1.TrackingState == JointTrackingState.Tracked)
            {
                drawPen = this.trackedBonePen;
            }
            graphics.DrawLine(drawPen, this.SkeletonPointToScreen(joint0.Position), this.SkeletonPointToScreen(joint1.Position));
        }

        private Point SkeletonPointToScreen(SkeletonPoint skelpoint)
        {
            DepthImagePoint depthPoint = coordinateMapper.MapSkeletonPointToDepthPoint(skelpoint, DepthImageFormat.Resolution640x480Fps30);
            return new Point(depthPoint.X, depthPoint.Y);
        }
    }
}
