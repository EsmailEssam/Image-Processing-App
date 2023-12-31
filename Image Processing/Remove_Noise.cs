using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Image_Processing
{
    class Remove_Noise
    {
        public static void sort(int []a, int n)
        {
            int tem, i, j;
            for (i = 0; i<n; i++)
            {
                for (j = i + 1; j < n; j++)
                {
                    if (a[i] > a[j])
                    {
                        tem = a[i];
                        a[i] = a[j];
                        a[j] = tem;
                    }
                }
            }
        }


        public static Bitmap MFtoRSaP(Bitmap bm)
        {
            int w = bm.Width, h = bm.Height, x, y;
            Bitmap bmResult = new Bitmap(bm.Width, bm.Height);
            int[] R = new int[9];
            int[] G = new int[9];
            int[] B = new int[9];

            for (y = 1; y < h-1; y++)
                for (x = 1; x < w-1; x++)
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

                    sort(R, 9);
                    sort(G, 9);
                    sort(G, 9);

                    bmResult.SetPixel(x, y, Color.FromArgb(R[4], G[4], B[4]));

                }
            return bmResult;

        }
    }
}
