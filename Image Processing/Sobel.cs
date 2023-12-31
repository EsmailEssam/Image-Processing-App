using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Image_Processing
{
    class Sobel
    {
        public static Bitmap sobel(Bitmap bm)
        {
            int w = bm.Width, h = bm.Height, x, y;

            Bitmap bmResult = new Bitmap(bm.Width, bm.Height);


            for (y = 1; y < h - 1; y++)
                for (x = 1; x < w - 1; x++)
                {
                    Color color1, color2, color3, color4, color5, color6;
                    color1 = bm.GetPixel(x - 1, y - 1);
                    color2 = bm.GetPixel(x + 1, y - 1);
                    color3 = bm.GetPixel(x - 1, y);
                    color4 = bm.GetPixel(x + 1, y);
                    color5 = bm.GetPixel(x - 1, y + 1);
                    color6 = bm.GetPixel(x + 1, y + 1);

                    int colorRed = color1.R * (-1) + color2.R + color3.R * (-2) + color4.R * (2) + color5.R * (-1) + color6.R;
                    int colorGreen = color1.G * (-1) + color2.G + color3.G * (-2) + color4.G * (2) + color5.G * (-1) + color6.G;
                    int colorBlue = color1.B * (-1) + color2.B + color3.B * (-2) + color4.B * (2) + color5.B * (-1) + color6.B;
                    int avg = (colorRed + colorGreen + colorBlue) / 3;

                    if (avg > 255)
                    {
                        avg = 255;
                    }

                    if (avg < 0)
                    {
                        avg = 0;
                    }

                    bmResult.SetPixel(x, y, Color.FromArgb(avg, avg, avg));

                }
            return bmResult;
        }
    }
}
