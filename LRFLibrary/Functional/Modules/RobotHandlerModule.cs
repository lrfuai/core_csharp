using LRFLibrary.Functional.Navigator;
using LRFLibrary.Functional.Skeletal.Condition;
using LRFLibrary.Functional.Skeletal.Tracking;
using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LRFLibrary.Functional.Modules
{
    public class RobotHandlerModule : IModule
    {

        #region Properties

        private INavigator navigator;
        private SkeletalTracker tracker;
        
        private ISkeltalCondition moveForwardCondition;
        private ISkeltalCondition moveBackwarCondition;
        private ISkeltalCondition moveLeftCondition;
        private ISkeltalCondition moveRigthCondition;
        private ISkeltalCondition doNothingCondition;


        public Skeleton[] Skeltons { get; private set; }

        #endregion

        #region Constructores

        public RobotHandlerModule(SkeletalTracker tracker, INavigator navigator)
        {
            this.tracker = tracker;
            this.navigator = navigator;

            ConditionGroup group = new ConditionGroup();
            group.add(new RigthHandDown());
            group.add(new LeftHandDown());
            this.moveForwardCondition = group;

            group = new ConditionGroup();
            group.add(new RigthHandUp());
            group.add(new LeftHandUp());
            this.moveBackwarCondition = group;

            group = new ConditionGroup();
            group.add(new LeftHandUp());
            group.add(new RigthHandDown());
            this.moveLeftCondition = group;

            group = new ConditionGroup();
            group.add(new RigthHandUp());
            group.add(new LeftHandDown());
            this.moveRigthCondition = group;

            this.doNothingCondition = new NoHands();

        }

        public RobotHandlerModule(SkeletalTracker tracker, INavigator navigator, ISkeltalCondition moveForward, ISkeltalCondition moveBackward, ISkeltalCondition moveLeft, ISkeltalCondition moveRigth)
        {
            tracker.NoTrack();
            this.tracker = tracker;
            this.navigator = navigator;
            this.moveForwardCondition = moveForward;
            this.moveBackwarCondition = moveBackward;
            this.moveLeftCondition = moveLeft;
            this.moveRigthCondition = moveRigth;
        }

        #endregion

        #region Methods
        private void RobotHandler_SkeletonFrameReady(object sender, Skeleton[] skeletons)
        {
            int skelQuantity = 0;
            Skeleton lastSkeleton = null;

            foreach (Skeleton skel in skeletons)
            {
                if (skel.TrackingState == SkeletonTrackingState.Tracked)
                {
                    skelQuantity++;
                    lastSkeleton = skel;
                }
            }

            if (lastSkeleton != null && skelQuantity == 1)
            {
                checkNavigationMovements(lastSkeleton);
            }
        }

        private void checkNavigationMovements(Skeleton skel)
        {
            if (!this.doNothingCondition.apply(skel))
            {
                if (this.moveRigthCondition.apply(skel))
                {
                    navigator.move(Movement.TurnRight);
                }
                else if (this.moveLeftCondition.apply(skel))
                {
                    navigator.move(Movement.TurnLeft);
                }
                else if (this.moveBackwarCondition.apply(skel))
                {
                    navigator.move(Movement.Backward);
                }
                else if (this.moveForwardCondition.apply(skel))
                {
                    navigator.move(Movement.Forward);
                }
            }
            
        }

        #endregion

        #region IModule
       public void run()
        {
            tracker.SkeletonFrameReady += RobotHandler_SkeletonFrameReady;
            tracker.NoTrack();
            tracker.Enable();
        }

        public void stop()
        {
            tracker.SkeletonFrameReady -= RobotHandler_SkeletonFrameReady;
            tracker.NoTrack();
            tracker.Disable();
        }

        #endregion
    }
}
