using System;
using System.Drawing;

using LRFLibrary.Functional.Map.Generic;

namespace LRFLibrary.Functional.Map.Element
{
    class Solid : IElement
    {
        public Color Color
        {
            get { return Color.Black; }
        }
        public bool isSolid() { return true; }
    }
}
