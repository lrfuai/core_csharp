using System;
using Microsoft.Kinect;

namespace LRFLibrary.Functional.Modules
{
    using Skeletal.Condition;
    using Skeletal.Tracking;
    using Navigator;

    public class PeopleFollowerModule : IModule
    {
        private INavigator navigator;
        private SkeletalTracker tracker;
        private ISkeltalCondition acceptance;
        private ISkeltalCondition decline;
        public Skeleton[] Skeltons { get; private set; }
        protected Skeleton trackedSkeleton;

        public PeopleFollowerModule(SkeletalTracker tracker, INavigator navigator)
        {
            this.tracker = tracker;
            this.navigator = navigator;
            this.acceptance = new OneHandUp();
            this.decline = new TwoHandsUp();
        }

        public PeopleFollowerModule(SkeletalTracker tracker, INavigator navigator, ISkeltalCondition acceptance, ISkeltalCondition decline)
        {
            this.tracker = tracker;
            this.navigator = navigator;
            this.acceptance = acceptance;
            this.decline = decline;
        }

        private void PeopleFollower_SkeletonFrameReady(object sender, Skeleton[] skeletons)
        {
            this.Skeltons = skeletons;
            updateTrackedSkeleton();
            checkTrackingAcceptanceOrDecline();
            checkTrackingMovements();
        }

        private void updateTrackedSkeleton()
        {
            if (trackedSkeleton != null)
            {
                foreach (Skeleton skel in Skeltons)
                {
                    if (skel.TrackingState == SkeletonTrackingState.Tracked && trackedSkeleton.TrackingId.Equals(skel.TrackingId))
                    {
                        trackedSkeleton = skel;
                    }
                }
            }
        }

        private void checkTrackingMovements()
        {
            if (trackedSkeleton != null)
            {
                DepthImagePoint position = this.tracker.SkeletonPositionToDepthImagePoint(trackedSkeleton.Position);
                
                if(position.Depth < 1500) { navigator.move(Movement.Backward); }
                if(position.Depth > 2000) { navigator.move(Movement.Forward); }

                if (position.X > 400) { navigator.move(Movement.TurnLeft); }
                if (position.X < 200) { navigator.move(Movement.TurnRight); }
                
            }
        }

        private void checkTrackingAcceptanceOrDecline()
        {
            bool someoneWasTracked = false;
            foreach (Skeleton skel in Skeltons)
            {
                if (skel.TrackingState == SkeletonTrackingState.Tracked)
                {
                    someoneWasTracked = true;
                    if (acceptance.apply(skel))
                    {
                        this.tracker.Track(skel);
                        trackedSkeleton = skel;
                    }
                    if (decline.apply(skel))
                    {
                        this.tracker.NoTrack();
                        trackedSkeleton = null;
                    }
                }
            }
            if (!someoneWasTracked)
            {
                tracker.NoTrack();
                trackedSkeleton = null;
            }
        }

        public void run()
        {
            tracker.SkeletonFrameReady += PeopleFollower_SkeletonFrameReady;
            tracker.NoTrack();
            tracker.Enable();
        }

        public void stop()
        {
            tracker.SkeletonFrameReady -= PeopleFollower_SkeletonFrameReady;
            tracker.NoTrack();
            tracker.Disable();
        }
    }
}
