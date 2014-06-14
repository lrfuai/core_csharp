using System;
using Microsoft.Kinect;

namespace LRFLibrary.Functional.Skeletal.Tracking
{
    using Skeletal.Condition;
    using Skeletal.Tracking;
    using Navigator;

    public class SkeletalSelector
    {
        private INavigator navigator;
        private SkeletalTracker tracker;
        private ISkeltalCondition acceptance;
        private ISkeltalCondition decline;
        public Skeleton[] Skeltons { get; private set; }
        protected Skeleton trackedSkeleton;

        public event EventHandler<SkeletonArgs> OnSkeletonTracked;
        public event EventHandler<EventArgs> onSkeletonNotTracked;
        public event EventHandler<SkeletonArgs> onSkeletonUpdated;

        public SkeletalSelector(SkeletalTracker tracker)
        {
            this.tracker = tracker;
            this.acceptance = new OneHandUp();
            this.decline = new TwoHandsUp();
        }

        public SkeletalSelector(SkeletalTracker tracker, ISkeltalCondition acceptance, ISkeltalCondition decline)
        {
            this.tracker = tracker;
            this.acceptance = acceptance;
            this.decline = decline;
        }

        private void PeopleFollower_SkeletonFrameReady(object sender, Skeleton[] skeletons)
        {
            this.Skeltons = skeletons;
            updateTrackedSkeleton();
            checkTrackingAcceptanceOrDecline();
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
                        if (this.onSkeletonUpdated != null)
                        {
                            this.onSkeletonUpdated(this, new SkeletonArgs(trackedSkeleton));
                        }
                    }
                }
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
                        if (this.OnSkeletonTracked != null)
                        {
                            this.OnSkeletonTracked(this, new SkeletonArgs(trackedSkeleton));
                        }
                    }
                    if (decline.apply(skel))
                    {
                        this.tracker.NoTrack();
                        trackedSkeleton = null;

                        if (this.onSkeletonNotTracked != null)
                        {
                            this.onSkeletonNotTracked(this, new EventArgs());
                        }
                    }
                }
            }
            if (!someoneWasTracked)
            {
                tracker.NoTrack();
                trackedSkeleton = null;
                if (this.onSkeletonNotTracked != null)
                {
                    this.onSkeletonNotTracked(this, new EventArgs());
                }
            }
        }

        public void Enable()
        {
            tracker.SkeletonFrameReady += PeopleFollower_SkeletonFrameReady;
            tracker.NoTrack();
            tracker.Enable();
        }

        public void Disable()
        {
            tracker.SkeletonFrameReady -= PeopleFollower_SkeletonFrameReady;
            tracker.NoTrack();
            tracker.Disable();
        }

        public class SkeletonArgs : EventArgs
        {
            Skeleton skel;
            public Skeleton Skeleton
            {
                get
                {
                    return skel;
                }
            }

            public SkeletonArgs(Skeleton skel)
            {
                this.skel = skel;
            }
        }
    }
}
