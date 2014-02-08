using System;

using LRFLibrary.Functional.Map.Generic;

namespace LRFLibrary.Functional.Map.Builder
{

    public delegate void MapChangedHandler(object sender, IMap map);

    public interface IMapBuilder
    {

        event MapChangedHandler MapChanged;

        IMap Map();

    }
}
