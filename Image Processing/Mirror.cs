using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Image_Processing
{
    class Mirror
    {
        public static Bitmap mirror(Bitmap bm)
        {
            int w = bm.Width, h = bm.Height, x, y;

            Bitmap bmResult = new Bitmap(bm.Width, bm.Height);
            int Red, Green, Blue;


            for (y = 1; y < h - 1; y++)
                for (x = w - 1; x >= 0; x--)
                {
                    //Process Red Pixels
                    Red = bm.GetPixel(x, y).R;

                    //Process Green Pixels
                    Green = bm.GetPixel(x, y).G;

                    //Process Blue Pixels
                    Blue = bm.GetPixel(x, y).B;

                    bmResult.SetPixel((w-1) - x, y, Color.FromArgb(Red, Green, Blue));

                }
            return bmResult;
        }
    }
}
