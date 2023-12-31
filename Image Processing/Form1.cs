using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using openCV;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processing
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }
        public static IplImage image1;
        public static IplImage img;
        public static Bitmap bmp;

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = " ";
            openFileDialog1.Filter = "JPEG|*JPG|Bitmap|*.bmp|All|*.*-11";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image1 = cvlib.CvLoadImage(openFileDialog1.FileName, cvlib.CV_LOAD_IMAGE_COLOR);
                    CvSize size = new CvSize(pictureBox1.Width, pictureBox1.Height);
                    IplImage resized_image = cvlib.CvCreateImage(size, image1.depth, image1.nChannels);
                    cvlib.CvResize(ref image1, ref resized_image, cvlib.CV_INTER_LINEAR);
                    pictureBox1.BackgroundImage = (Image)resized_image;
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);
            int srcAdd = image1.imageData.ToInt32();
            int dstAdd = img.imageData.ToInt32();

            unsafe
            {
                int srcIndex, dstIndex;
                for(int r = 0; r < img.height; r++)
                {
                    for(int c = 0; c < img.width; c++)
                    {
                        srcIndex = dstIndex = (img.width * r * img.nChannels) + (c * img.nChannels);
                        *(byte*)(dstAdd + dstIndex + 0) = 0;
                        *(byte*)(dstAdd + dstIndex + 1) = 0;
                        *(byte*)(dstAdd + dstIndex + 2) = *(byte*)(srcAdd + srcIndex + 2);
                    }
                }
            }
            CvSize size = new CvSize(pictureBox2.Width, pictureBox2.Height);
            IplImage resized_image = cvlib.CvCreateImage(size, img.depth, img.nChannels);
            cvlib.CvResize(ref img, ref resized_image, cvlib.CV_INTER_LINEAR);
            pictureBox2.Image = (Image)resized_image;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);
            int srcAdd = image1.imageData.ToInt32();
            int dstAdd = img.imageData.ToInt32();

            unsafe
            {
                int srcIndex, dstIndex;
                for (int r = 0; r < img.height; r++)
                {
                    for (int c = 0; c < img.width; c++)
                    {
                        srcIndex = dstIndex = (img.width * r * img.nChannels) + (c * img.nChannels);
                        *(byte*)(dstAdd + dstIndex + 0) = 0;
                        *(byte*)(dstAdd + dstIndex + 1) = *(byte*)(srcAdd + srcIndex + 1);
                        *(byte*)(dstAdd + dstIndex + 2) = 0;
                    }
                }
            }
            CvSize size = new CvSize(pictureBox2.Width, pictureBox2.Height);
            IplImage resized_image = cvlib.CvCreateImage(size, img.depth, img.nChannels);
            cvlib.CvResize(ref img, ref resized_image, cvlib.CV_INTER_LINEAR);
            pictureBox2.Image = (Image)resized_image;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            img = cvlib.CvCreateImage(new CvSize(image1.width, image1.height), image1.depth, image1.nChannels);
            int srcAdd = image1.imageData.ToInt32();
            int dstAdd = img.imageData.ToInt32();

            unsafe
            {
                int srcIndex, dstIndex;
                for (int r = 0; r < img.height; r++)
                {
                    for (int c = 0; c < img.width; c++)
                    {
                        srcIndex = dstIndex = (img.width * r * img.nChannels) + (c * img.nChannels);
                        *(byte*)(dstAdd + dstIndex + 0) = *(byte*)(srcAdd + srcIndex + 0);
                        *(byte*)(dstAdd + dstIndex + 1) = 0;
                        *(byte*)(dstAdd + dstIndex + 2) = 0;
                    }
                }
            }
            CvSize size = new CvSize(pictureBox2.Width, pictureBox2.Height);
            IplImage resized_image = cvlib.CvCreateImage(size, img.depth, img.nChannels);
            cvlib.CvResize(ref img, ref resized_image, cvlib.CV_INTER_LINEAR);
            pictureBox2.Image = (Image)resized_image;
        }

        private void convertToGrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bmp = (Bitmap)image1;
            int width = bmp.Width;
            int hight = bmp.Height;
            Color p;
            for (int y = 0; y < hight; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    p = bmp.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;
                    int avg = (r + g + b) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));


                    pictureBox2.Image = (Image)bmp;
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        public void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void histogramToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.frm1 = this;
            frm2.Show();
        }

        private void removeNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm2 = Remove_Noise.MFtoRSaP((Bitmap)image1);

            pictureBox2.Image = (Image)bm2;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void smoothingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm2 = Smoothing.smooothing((Bitmap)image1);

            pictureBox2.Image = (Image)bm2;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void averagingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm3 = Averaging.averaging((Bitmap)image1);

            pictureBox2.Image = (Image)bm3;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm4 = Mirror.mirror((Bitmap)image1);

            pictureBox2.Image = (Image)bm4;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void laplaceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Bitmap bm5 = Laplace.laplace((Bitmap)image1);

            pictureBox2.Image = (Image)bm5;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void solarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm6 = Solarize.solarize((Bitmap)image1);

            pictureBox2.Image = (Image)bm6;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm7 = Sobel.sobel((Bitmap)image1);

            pictureBox2.Image = (Image)bm7;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void sharpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap bm8 = Sharpen.sharpen ((Bitmap)image1);

            pictureBox2.Image = (Image)bm8;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
