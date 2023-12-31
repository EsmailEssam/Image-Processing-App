using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Image_Processing
{
    class Sharpen
    {
        public static Bitmap sharpen(Bitmap bm)
        {
            int w = bm.Width, h = bm.Height, x, y;
            Bitmap bmResult = new Bitmap(bm.Width, bm.Height);
            int Red, Green, Blue;

            for (y = 1; y < h - 1; y++)
                for (x = 1; x < w - 1; x++)
                {
                    //Process Red Pixels
                    Red = bm.GetPixel(x - 1, y - 1).R * -1 +
                           bm.GetPixel(x, y - 1).R * -1 +
                           bm.GetPixel(x + 1, y - 1).R - 1 +
                           bm.GetPixel(x - 1, y).R * -1 +
                           bm.GetPixel(x, y).R * 9 +
                           bm.GetPixel(x + 1, y).R * -1 +
                           bm.GetPixel(x - 1, y + 1).R * -1 +
                           bm.GetPixel(x, y + 1).R * -1 +
                           bm.GetPixel(x + 1, y + 1).R * -1;

                    if (Red > 255) { Red = 255; }
                    if (Red < 0) { Red = 0; }

                    //Process Green Pixels
                    Green = bm.GetPixel(x - 1, y - 1).G * -1 +
                           bm.GetPixel(x, y - 1).G * -1 +
                           bm.GetPixel(x + 1, y - 1).G - 1 +
                           bm.GetPixel(x - 1, y).G * -1 +
                           bm.GetPixel(x, y).G * 9 +
                           bm.GetPixel(x + 1, y).G * -1 +
                           bm.GetPixel(x - 1, y + 1).G * -1 +
                           bm.GetPixel(x, y + 1).G * -1 +
                           bm.GetPixel(x + 1, y + 1).G * -1;

                    if (Green > 255) { Green = 255; }
                    if (Green < 0) { Green = 0; }

                    //Process Blue Pixels
                    Blue = bm.GetPixel(x - 1, y - 1).B * -1 +
                           bm.GetPixel(x, y - 1).B * -1 +
                           bm.GetPixel(x + 1, y - 1).B - 1 +
                           bm.GetPixel(x - 1, y).B * -1 +
                           bm.GetPixel(x, y).B * 9 +
                           bm.GetPixel(x + 1, y).B * -1 +
                           bm.GetPixel(x - 1, y + 1).B * -1 +
                           bm.GetPixel(x, y + 1).B * -1 +
                           bm.GetPixel(x + 1, y + 1).B * -1;

                    if (Blue > 255) { Blue = 255; }
                    if (Blue < 0) { Blue = 0; }


                    bmResult.SetPixel(x, y, Color.FromArgb(Red, Green, Blue));

                }
            return bmResult;

        }
    }
}
