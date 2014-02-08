using System;
using System.Collections.Generic;

namespace LRFLibrary.Functional.Navigator
{
    class LinearNavigator : INavigator
    {
        public event NavigatorMovementHandler NavigatorMovement;

        private INavigator navigator;

        public LinearNavigator(INavigator navigator)
        {
            this.navigator = navigator;
        }

        public void move(Movement movement)
        {
            navigator.move(movement);
            if (NavigatorMovement != null)
                NavigatorMovement( this, movement);
        }
    }
}
