using System;

namespace LRFLibrary.Functional.Map.Generic
{
    class TailMap : IMap
    {
        public int sizeX { get; private set; }
        public int sizeY { get; private set; }

        private ICell[,] map;

        public TailMap(int sizeX = 400, int sizeY = 400)
        {
            this.sizeX = sizeX;
            this.sizeY = sizeY;
            map = new Cell[sizeX,sizeY];
        }

        public void set(IPosition position, ICell element) {
            this.map[position.x,position.y] = element;
        }

        public ICell get(IPosition position)
        {
           return this.map[position.x,position.y];
        }

        public bool exists(IPosition position)
        {
            return position.x >= 0 && position.x < sizeX && position.y >= 0 && position.y < sizeY; 
        }
    }
}
