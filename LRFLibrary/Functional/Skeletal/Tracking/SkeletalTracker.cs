using System;
using System.Collections.Generic;

using Microsoft.Kinect;

namespace LRFLibrary.Functional.Skeletal.Tracking
{
    public delegate void SkeletonFrameReadyHandler (object sender, Skeleton[] skeletons);

    public class SkeletalTracker
    {
        public event SkeletonFrameReadyHandler SkeletonFrameReady;
        private KinectSensor sensor;

        public SkeletalTracker(KinectSensor sensor)
        {
            this.sensor = sensor;
            this.sensor.SkeletonStream.Enable();
            this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;
        }

        public DepthImagePoint SkeletonPositionToDepthImagePoint(SkeletonPoint point)
        {
            return this.sensor.CoordinateMapper.MapSkeletonPointToDepthPoint(point, this.sensor.DepthStream.Format);
        }

        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);
                }
            }
            if (SkeletonFrameReady != null)
                SkeletonFrameReady(this, skeletons);
        }

        public void Enable()
        {
            this.sensor.SkeletonStream.Enable();
        }

        public void Disable()
        {
            this.sensor.SkeletonStream.Disable();
        }

        public void Track(Skeleton skel)
        {
            this.sensor.SkeletonStream.AppChoosesSkeletons = true;
            this.sensor.SkeletonStream.ChooseSkeletons(skel.TrackingId);
        }

        public void NoTrack()
        {
            this.sensor.SkeletonStream.AppChoosesSkeletons = false;
            //this.sensor.SkeletonStream.ChooseSkeletons();
        }
    }
}
