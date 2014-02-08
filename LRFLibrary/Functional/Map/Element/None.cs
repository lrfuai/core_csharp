using System;
using System.Drawing;

using LRFLibrary.Functional.Map.Generic;

namespace LRFLibrary.Functional.Map.Element
{
    class None : IElement
    {
        Color IElement.Color
        {
            get { return Color.LightGray; }
        }

        public bool isSolid() { return false; }
    }
}
