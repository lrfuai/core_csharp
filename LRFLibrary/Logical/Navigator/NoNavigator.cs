using System;
using System.IO.Ports;

namespace LRFLibrary.Logical.Navigator
{
    class NoNavigator : INavigator
    {
        public void moveFordward(){}
        public void moveBackward(){}
        public void turnLeft(){}
        public void turnRight(){}
    }
}
