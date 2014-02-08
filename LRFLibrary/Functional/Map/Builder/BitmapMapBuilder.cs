using System;
using System.Drawing;

using LRFLibrary.Functional.Map.Utils;
using LRFLibrary.Functional.Map.Element;
using LRFLibrary.Functional.Map;

namespace LRFLibrary.Functional.Map.Builder
{
    class BitmapMapBuilder : BaseMapBuilder
    {
        private Bitmap originalMap;

        public BitmapMapBuilder(Bitmap image)
        {
            originalMap = image;
            setMap(MapConverter.BmpToMap(image));
        }

    }
}
