using System;

namespace LRFLibrary.Functional.Map.Generic
{
    public interface IMap
    {
        int sizeX { get; }
        int sizeY { get; }
        void set(IPosition position, ICell element);
        ICell get(IPosition position);
        bool exists(IPosition position);
    }
}