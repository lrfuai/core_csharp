using System;
using System.Collections.Generic;
using System.Drawing;

using LRFLibrary.Functional.Navigator;


namespace LRFLibrary.Functional.Positioner
{
    class Positioner : IPositioner
    {
        public event PositionChangedHandler PositionChanged;

        public Point position {get; set;}
        public float angle { get; set; }

        private Direction curDirection;

        private static readonly Dictionary<Direction, Direction> TurnRight = new Dictionary<Direction, Direction>
        {
            { Direction.Up, Direction.Right },
            { Direction.Right, Direction.Down },
            { Direction.Down, Direction.Left },
            { Direction.Left, Direction.Up }
        };

        private static readonly Dictionary<Direction, Direction> TurnLeft = new Dictionary<Direction, Direction>
        {
            { Direction.Up, Direction.Left },
            { Direction.Right, Direction.Up },
            { Direction.Down, Direction.Right },
            { Direction.Left, Direction.Down }
        };
       
        private static readonly Dictionary<Direction, Point> Displacements = new Dictionary<Direction, Point>
        {
            { Direction.Up, new Point { X = 0, Y = -1 } },
            { Direction.Right, new Point { X = 1, Y = 0 } },
            { Direction.Down, new Point { X = 0, Y = 1 } },
            { Direction.Left, new Point { X = -1, Y = 0 } }
        };

        private int degreesInRightAngle {get; set;}
        private int displacementAmount { get; set; }


        public Positioner()
        {
            position = new Point(0, 0);
            curDirection = Direction.Left;
            angle = 0;
            degreesInRightAngle = 90;
            displacementAmount = 1;
        }

        public Positioner(Point point, Direction direction = Direction.Left, int degreesInRightAngle = 90, int displacementAmount = 1)
        {
            this.position = point;
            this.curDirection = direction;
            this.degreesInRightAngle = degreesInRightAngle;
            this.displacementAmount = displacementAmount;
        }

        private void move(Direction direction)
        {
            int posx, posy;

            switch (direction)
            {
                case Direction.Up:
                    posx = (/*map.sizeX +*/ position.X + (displacementAmount * Displacements[curDirection].X)) /*% map.sizeX*/;
                    posy = (/*map.sizeY + */position.Y + (displacementAmount * Displacements[curDirection].Y)) /*% map.sizeY*/;
                    position = new Point(posx, posy);
                    break;

                case Direction.Down:
                    posx = (/*map.sizeX +*/ position.X - (displacementAmount * Displacements[curDirection].X)) /*% map.sizeX*/;
                    posy = (/*map.sizeY +*/ position.Y - (displacementAmount * Displacements[curDirection].Y)) /*% map.sizeY*/;
                    position = new Point(posx, posy);
                    break;

                case Direction.Left:
                    curDirection = TurnLeft[curDirection];
                    // We take a left turn to mean a counter-clockwise right angle rotation for the displayed turtle.
                    angle -= degreesInRightAngle;
                    break;

                case Direction.Right:
                    curDirection = TurnRight[curDirection];
                    // We take a right turn to mean a clockwise right angle rotation for the displayed turtle.
                    angle += degreesInRightAngle;
                    break;
            }
            if (PositionChanged != null)
                PositionChanged(this, position, curDirection);
        }

        public void NavigatorMovementHandler(object sender, Movement movement) {
            switch (movement)
            {
                case Movement.Forward: move(Direction.Up); break;
                case Movement.Backward: move(Direction.Down); break;
                case Movement.TurnLeft: move(Direction.Left); break;
                case Movement.TurnRight: move(Direction.Right); break;
            }
  
        }
    }
}
