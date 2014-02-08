using System;
using System.Drawing;

namespace LRFLibrary.Functional.Navigator
{
    public delegate void NavigatorMovementHandler(object sender, Movement movement);

    public interface INavigator
    {

        event NavigatorMovementHandler NavigatorMovement;

        void move(Movement movement);

    }
}
