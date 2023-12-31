using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Image_Processing
{
    class Solarize
    {
        public static Bitmap solarize(Bitmap bm)
        {
            int w = bm.Width, h = bm.Height, x, y;

            Bitmap bmResult = new Bitmap(bm.Width, bm.Height);

            

            for (y = 1; y < h - 1; y++)
                for (x = 1; x < w - 1; x++)
                {
                    int Red = 0, Green = 0, Blue = 0;

                    if (bm.GetPixel(x, y).R < 120) { Red = 255 - bm.GetPixel(x, y).R; }
                    if (bm.GetPixel(x, y).G < 120) { Green = 255 - bm.GetPixel(x, y).G; }
                    if (bm.GetPixel(x, y).B < 120) { Blue = 255 - bm.GetPixel(x, y).B; }
                    

                    

                    bmResult.SetPixel(x, y, Color.FromArgb(Red, Green, Blue));

                }
            return bmResult;
        }
    }
}
