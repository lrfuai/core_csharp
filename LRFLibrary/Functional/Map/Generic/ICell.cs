using System;

using LRFLibrary.Functional.Map.Element;

namespace LRFLibrary.Functional.Map.Generic
{
    public interface ICell
    {
        IElement Element { get; set; } 
    }
}
