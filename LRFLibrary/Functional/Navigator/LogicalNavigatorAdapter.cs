using System;

using LowerNavigator = LRFLibrary.Logical.Navigator;

namespace LRFLibrary.Functional.Navigator
{
    class LogicalNavigatorAdapter : INavigator 
    {
        public event NavigatorMovementHandler NavigatorMovement;
        
        private LowerNavigator.INavigator adaptee;

        public LogicalNavigatorAdapter(LowerNavigator.INavigator navigator)
        {
            this.adaptee = navigator;
        }

        public void move(Movement movement)
        {
            switch (movement)
            {
                case Movement.Forward: adaptee.moveFordward(); break;
                case Movement.Backward: adaptee.moveBackward(); break;
                case Movement.TurnLeft: adaptee.turnLeft(); break;
                case Movement.TurnRight: adaptee.turnRight(); break;
            }
            if (NavigatorMovement != null)
                NavigatorMovement(this, movement);
        }
    }
}

