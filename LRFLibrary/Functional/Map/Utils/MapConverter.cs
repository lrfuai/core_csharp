using System;
using System.Drawing;

using LRFLibrary.Functional.Map.Element;
using LRFLibrary.Functional.Map.Generic;

namespace LRFLibrary.Functional.Map.Utils
{
    public static class MapConverter
    {
        public static IMap BmpToMap(Bitmap bmp)
        {
            IMap map = new TailMap(bmp.Width, bmp.Width);
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color color = bmp.GetPixel(x, y);
                    if (Color.Black.ToArgb().Equals(color.ToArgb()))
                        map.set(new Position(x, y), new Cell(new Solid()));
                    else
                        map.set(new Position(x, y), new Cell(new None()));
                }
            }
            return map;
        }

        public static Bitmap MapToBmp(IMap map)
        {
            Bitmap bmp = new Bitmap(map.sizeX, map.sizeY);
            for (int x = 0; x < map.sizeX; x++)
            {
                for (int y = 0; y < map.sizeY; y++)
                {
                    IElement element = map.get(new Position(x, y)).Element;
                    if (element.isSolid())
                        bmp.SetPixel(x, y, Color.Black);
                    else
                        bmp.SetPixel(x, y, Color.LightGray);
                }
            }
            return bmp;
        }

    }
}
