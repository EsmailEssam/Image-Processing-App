﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Image_Processing
{
    class Laplace
    {
        public static Bitmap laplace(Bitmap bm)
        {
            int w = bm.Width, h = bm.Height, x, y;

            Bitmap bmResult = new Bitmap(bm.Width, bm.Height);


            for (y = 1; y < h - 1; y++)
                for (x = 1; x < w - 1; x++)
                {
                    Color color1, color2, color3, color4, color5;
                    color1 = bm.GetPixel(x, y - 1);
                    color2 = bm.GetPixel(x - 1, y);
                    color3 = bm.GetPixel(x, y);
                    color4 = bm.GetPixel(x + 1, y);
                    color5 = bm.GetPixel(x, y + 1);

                    int colorRed = color1.R + color2.R + color3.R * (-4) + color4.R + color5.R;
                    int colorGreen = color1.G + color2.G + color3.G * (-4) + color4.G + color5.G;
                    int colorBlue = color1.B + color2.B + color3.B * (-4) + color4.B + color5.B;
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
