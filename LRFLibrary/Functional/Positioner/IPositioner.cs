using System;
using System.Drawing;

namespace LRFLibrary.Functional.Positioner
{
    public delegate void PositionChangedHandler (object sender, Point position, Direction direction);

    public interface IPositioner
    {
        event PositionChangedHandler PositionChanged;
        
    }
}
