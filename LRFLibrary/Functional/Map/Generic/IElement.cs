using System;
using System.Drawing;

namespace LRFLibrary.Functional.Map.Generic
{
    public interface IElement
    {
        Color Color {get;}
        bool isSolid();
    }
}
