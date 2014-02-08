using System;

namespace LRFLibrary.Functional.Map.Generic
{
    class Position : IPosition
    {
        public int x { get; set; }
        public int y { get; set; }

        public Position()
        {
            this.x = 0;
            this.y = 0;
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
