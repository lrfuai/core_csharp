using System;
using System.Collections.Generic;
using System.Drawing;

using LRFLibrary.Functional.Map.Utils;
using LRFLibrary.Functional.Positioner;
using LRFLibrary.Functional.Map.Generic;

namespace LRFLibrary.Functional.Map.Builder
{
    class BaseMapBuilder : IMapBuilder
    {
        public event MapChangedHandler MapChanged;

        private IMap map;
        
        protected void setMap(IMap map)
        {
            this.map = map;
            if (MapChanged != null)
                MapChanged(this, map);
        }

        public IMap Map()
        {
            return this.map;
        }

        public void PositionChangedHandler (object sender, Point point, Direction direction)
        {
            this.map.set(PositionConverter.toPosition(point), new Cell(new Element.Item()));
            if (MapChanged != null)
                MapChanged(this, map);
        }
    }
}
