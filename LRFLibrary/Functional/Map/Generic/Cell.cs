using System;
using LRFLibrary.Functional.Map.Element;

namespace LRFLibrary.Functional.Map.Generic
{
    class Cell : ICell
    {
        public IElement Element { get; set; }

        public Cell ()
        {
            Element = new Element.None();
        }

        public Cell (IElement element)
        {
            this.Element = element;
        }

    }
}
