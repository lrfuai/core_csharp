using System;

namespace LRFLibrary.Logical.Navigator
{
    public interface INavigator
    {
        void moveFordward();
        void moveBackward();
        void turnLeft();
        void turnRight();
    }
}
