using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Image_Processing
{
    class Smoothing
    {
        public static int sum(double[] a, int n)
        {
            double[] s = { 1 / 16, 2 / 16, 1 / 16, 2 / 16, 4 / 16, 2 / 16, 1 / 16, 2 / 16, 1 / 16 };
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += a[i] * s[i];
            }
            return (int)Math.Round(sum);
        }

        public static Bitmap smooothing(Bitmap bm)
        {
            int w = bm.Width, h = bm.Height, x, y;
            
            
            Bitmap bmResult = new Bitmap(bm.Width, bm.Height);
            double[] R = new double[9];
            double[] G = new double[9];
            double[] B = new double[9];

            for (y = 1; y < h - 1; y++)
                for (x = 1; x < w - 1; x++)
                {
                    //Process Red Pixels
                    R[0] = bm.GetPixel(x - 1, y - 1).R;
                    R[1] = bm.GetPixel(x, y - 1).R;
                    R[2] = bm.GetPixel(x + 1, y - 1).R;
                    R[3] = bm.GetPixel(x - 1, y).R;
                    R[4] = bm.GetPixel(x, y).R;
                    R[5] = bm.GetPixel(x + 1, y).R;
                    R[6] = bm.GetPixel(x - 1, y + 1).R;
                    R[7] = bm.GetPixel(x, y + 1).R;
                    R[8] = bm.GetPixel(x + 1, y + 1).R;

                    //Process Green Pixels
                    G[0] = bm.GetPixel(x - 1, y - 1).G;
                    G[1] = bm.GetPixel(x, y - 1).G;
                    G[2] = bm.GetPixel(x + 1, y - 1).G;
                    G[3] = bm.GetPixel(x - 1, y).G;
                    G[4] = bm.GetPixel(x, y).G;
                    G[5] = bm.GetPixel(x + 1, y).G;
                    G[6] = bm.GetPixel(x - 1, y + 1).G;
                    G[7] = bm.GetPixel(x, y + 1).G;
                    G[8] = bm.GetPixel(x + 1, y + 1).G;

                    //Process Blue Pixels
                    B[0] = bm.GetPixel(x - 1, y - 1).B;
                    B[1] = bm.GetPixel(x, y - 1).B;
                    B[2] = bm.GetPixel(x + 1, y - 1).B;
                    B[3] = bm.GetPixel(x - 1, y).B;
                    B[4] = bm.GetPixel(x, y).B;
                    B[5] = bm.GetPixel(x + 1, y).B;
                    B[6] = bm.GetPixel(x - 1, y + 1).B;
                    B[7] = bm.GetPixel(x, y + 1).B;
                    B[8] = bm.GetPixel(x + 1, y + 1).B;

                    bmResult.SetPixel(x, y, Color.FromArgb(sum(R, 9), sum(G, 9), sum(B, 9)));

                }
            return bmResult;
        }
    }
}
