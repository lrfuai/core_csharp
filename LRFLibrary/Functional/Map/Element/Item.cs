using System;
using System.Drawing;

using LRFLibrary.Functional.Map.Generic;

namespace LRFLibrary.Functional.Map.Element
{
    class Item : Solid, IElement
    {
        Color IElement.Color
        {
            get { return Color.Red; }
        }
    }
}
