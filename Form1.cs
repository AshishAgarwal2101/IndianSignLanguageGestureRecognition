using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using AForge.Video.DirectShow;
using AForge.Video;
using libsvm;
using System.Diagnostics;
using System.Threading;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using AForge.Imaging.Textures;

namespace IndianSignLanguageGestureRecognition
{
    public partial class Form1 : Form
    {
        Bitmap orgImage, imageGot;
        static int maxNoOfImages = 1300;
        Bitmap[] img = new Bitmap[maxNoOfImages];
        Bitmap[] gotImages = new Bitmap[maxNoOfImages];
        static int orgImWidth = 400, orgImHeight = 400;
        double[,] histo = new double[6, 6];
        int[] skinArray = new int[orgImWidth];
        double[,] histo1 = new double[maxNoOfImages, 36];
        int[,] totHisto = new int[maxNoOfImages, 36];
        String s = "";
        VideoCaptureDevice videoSource;
        String[] sss = new String[maxNoOfImages];
        int noOfImages = 0, k, letter, numFrames = 0;
        C_SVC model;
        Stopwatch stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            var val = od.ShowDialog();
            if (val == DialogResult.OK)
            {
                orgImage = new Bitmap(od.FileName);
                orgImage = new Bitmap(orgImage, new Size(400, 400));
                imageGot = new Bitmap(orgImage);
                //pictureBox1.Image = imageGot;
                //work on image
                testing();

            }
        }
        private void testing()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate {
                    detectSkin();
                    fillHoles();
                    extractLargestBlob();
                    andImages();
                    twoHxtwoH();
                    edgeDetect();
                    //making svm_node
                    svm_node[] svmNode = nodeMaking();
                    var pred_y = model.Predict(svmNode);
                    //MessageBox.Show((char)(pred_y + 64) + "");
                    label1.Text = (char)(pred_y + 64) + "";
                    pictureBox1.Image = imageGot;
                });
            }
            /*detectSkin();
            fillHoles();
            extractLargestBlob();
            andImages();
            twoHxtwoH();
            edgeDetect();
            //making svm_node
            svm_node[] svmNode = nodeMaking();
            var pred_y = model.Predict(svmNode);
            //MessageBox.Show((char)(pred_y + 64) + "");
            textBox1.Text = textBox1.Text + (char)(pred_y + 64) + "";*/
        }
        private svm_node[] nodeMaking()
        {
            String st = "";
            int l = 0;
            svm_node[] svmNodes = new svm_node[36];
            //svmNode.index = 0;
            //svmNode.value = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    svm_node svmNode = new svm_node();
                    double value = countEdgesForBlock(i * 33, j * 33, 33, 33);
                    svmNode.index = l+1;
                    svmNode.value = value;
                    svmNodes[l++] = svmNode;
                }
                int q = 132;
                for (int j = 4; j < 6; j++)
                {
                    svm_node svmNode = new svm_node();
                    double value = countEdgesForBlock(i * 33, q, 34, 34);
                    svmNode.index = l+1;
                    svmNode.value = value;
                    q = q + 34;
                    svmNodes[l++] = svmNode;
                }
            }
            int p = 132;
            for (int i = 4; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    svm_node svmNode = new svm_node();
                    double value = countEdgesForBlock(p, j * 33, 33, 33);
                    svmNode.index = l+1;
                    svmNode.value = value;
                    svmNodes[l++] = svmNode;
                }

                int q = 132;
                for (int j = 4; j < 6; j++)
                {
                    svm_node svmNode = new svm_node();
                    double value = countEdgesForBlock(p, q, 34, 34);
                    svmNode.index = l+1;
                    svmNode.value = value;
                    q = q + 34;
                    svmNodes[l++] = svmNode;
                }
                p = p + 34;
            }
            return svmNodes;
        }

        private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* ------------------------preprocessing--------------------------- */
            detectSkin();

        }

        private void fillHolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillHoles();
        }

        private void x200ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            twoHxtwoH();
        }

        private void andImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            andImages();
        }

        private void detectEdgesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edgeDetect();
        }

        private void extractLargestBlobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extractLargestBlob();
        }

        private void histogramArrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            histoArray();
        }
        private void doAll()
        {
            detectSkin();
            fillHoles();
            extractLargestBlob();
            andImages();
            twoHxtwoH();
            edgeDetect();
            histoArray();
            gotImages[k] = imageGot;
            Directory.CreateDirectory(@"D:\results\Bitmaps\" + (char)(letter + 64));
            gotImages[k].Save(@"D:\results\Bitmaps\" + (char)(letter + 64) + "\\" + k + ".jpg");
           

        }

        private void doAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doAll();
        }

        private void edgeDetect()
        {
            Bitmap news = new Bitmap(imageGot);
            GrayscaleBT709 gs = new GrayscaleBT709();
            imageGot = gs.Apply(imageGot);
            CannyEdgeDetector cn = new CannyEdgeDetector();
            cn.LowThreshold = 0;
            cn.HighThreshold = 0;
            cn.GaussianSigma = 1.4;
            imageGot = cn.Apply(imageGot);
            pictureBox1.Image = imageGot;


        }

        private void extractLargestBlob()
        {
            ExtractBiggestBlob biggestBlob = new ExtractBiggestBlob();
            Bitmap newImage = biggestBlob.Apply(imageGot);

            int newImHeight = newImage.Height;
            int newImWidth = newImage.Width;

            //textBox1.Text = newImWidth + "    " + newImHeight;

            // create filter
            BlobsFiltering filter = new BlobsFiltering();
            filter.CoupledSizeFiltering = true;
            filter.MinWidth = newImHeight;
            filter.MinHeight = newImWidth;
            imageGot = filter.Apply(imageGot);


            //palm extraction(without band) ------------------
            /*int[] der1 = new int[400];
            int[] der2 = new int[400];
            Color clr = Color.FromArgb(Color.White.ToArgb());
            Color clr1 = Color.FromArgb(Color.Black.ToArgb());
            int imgHeight = imageGot.Height;
            int imgWidth = imageGot.Width;
            for (int i = 0; i < imgWidth; i++)
            {
                for (int j = 0; j < imgHeight; j++)
                {
                    Color rgb = imageGot.GetPixel(i, j);
                    if (rgb == clr)
                        skinArray[j]++;
                }
            }
            
            for (int i = 0; i < imgHeight; i++)
            {
                //sc = sc + skinArray[i] + "   ";
                if (i < (imgHeight - 1))
                    der1[i] = skinArray[i + 1] - skinArray[i];
            }
            int max1 = 0, max2 = 0, pos = 0;
            //String sa = "";
            for (int i = 0; i < imgHeight - 2; i++)
            {
                der2[i] = der1[i + 1] - der1[i];
                //sa = sa + der2[i] + "  ";
                if (i != 0 && der2[i] < 0) //for any negative value of der2
                {
                    if (der2[i - 1] >= max1 && der1[i] > max2) //take the maximum value of der2 before any negative value of der2... plus maximum value of der1 corresponding to any negative value of der2
                    {
                        max2 = der1[i];
                        max1 = der2[i - 1];
                        pos = i;
                        //break;
                    }
                }

            }*/
            //palm extraction(without band) ------------------
            /*for (int i = imgHeight-1; i >= 1; i--)
            {
                //sc = sc + skinArray[i] + "   ";
                //MessageBox.Show("i-1 = " + (i - 1) + " .... i=" + i);
                der1[i] = skinArray[i - 1] - skinArray[i];
            }
            int max1 = 0, max2 = 0, pos = 0;
            //String sa = "";
            for (int i = imgHeight-1; i >= 2; i--)
            {
                der2[i] = der1[i - 1] - der1[i];
                //sa = sa + der2[i] + "  ";
                if (i != imgHeight-1 && der2[i] < 0) //for any negative value of der2
                {
                    if (der2[i + 1] >= max1 && der1[i] > max2) //take the maximum value of der2 before any negative value of der2... plus maximum value of der1 corresponding to any negative value of der2
                    {
                        max2 = der1[i];
                        max1 = der2[i + 1];
                        pos = i;
                        //break;
                    }
                }

            }
            imageGot = new Bitmap(imageGot);
            for (int i = 0; i < imgWidth; i++)
            {
                //skinArray[i] = 0;
                for (int j = imgHeight-1; j >= pos; j--)
                {
                    imageGot.SetPixel(i, j, clr1);
                }
            }*/
            //palm extraction ends ---------
            pictureBox1.Image = imageGot;
        }

        private void andImages()
        {
            imageGot = new Bitmap(imageGot);
            Bitmap newImage = new Bitmap(orgImage);

            int imgHeight = imageGot.Height;
            int imgWidth = imageGot.Width;

            var rect = new Rectangle(0, 0, imgWidth, imgHeight);
            var data1 = imageGot.LockBits(rect, ImageLockMode.ReadWrite, imageGot.PixelFormat);
            var data2 = newImage.LockBits(rect, ImageLockMode.ReadWrite, newImage.PixelFormat);
            var depth1 = Bitmap.GetPixelFormatSize(data1.PixelFormat) / 8; //bytes per pixel
            var depth2 = Bitmap.GetPixelFormatSize(data2.PixelFormat) / 8;

            var buffer1 = new byte[data1.Width * data1.Height * depth1];
            var buffer2 = new byte[data2.Width * data2.Height * depth2];

            //copy pixels to buffer
            Marshal.Copy(data1.Scan0, buffer1, 0, buffer1.Length);
            Marshal.Copy(data2.Scan0, buffer2, 0, buffer2.Length);
            ProcessAndImages(buffer1, buffer2, 0, 0, data1.Width, data1.Height, data1.Width, depth1, depth2);
            /*System.Threading.Tasks.Parallel.Invoke(
                () =>
                {
                    //upper-left
                    Process(buffer, 0, 0, data.Width / 2, data.Height / 2, data.Width, depth);
                },
                () =>
                {
                    //upper-right
                    Process(buffer, data.Width / 2, 0, data.Width, data.Height / 2, data.Width, depth);
                },
                () =>
                {
                    //lower-left
                    Process(buffer, 0, data.Height / 2, data.Width / 2, data.Height, data.Width, depth);
                },
                () =>
                {
                    //lower-right
                    Process(buffer, data.Width / 2, data.Height / 2, data.Width, data.Height, data.Width, depth);
                }
            );*/

            //Copy the buffer back to image
            Marshal.Copy(buffer1, 0, data1.Scan0, buffer1.Length);
            Marshal.Copy(buffer2, 0, data2.Scan0, buffer2.Length);

            imageGot.UnlockBits(data1);
            newImage.UnlockBits(data2);
            //pictureBox1.Image = orgImage;
            //AND orgImage and imageGot
            /*for (int i = 0; i < orgImWidth; i++)
            {
                for (int j = 0; j < orgImHeight; j++)
                {
                    Color rgb = newImage.GetPixel(i, j);
                    int r = rgb.R;
                    int g = rgb.G;
                    int b = rgb.B;
                    Color rgb1 = imageGot.GetPixel(i, j);
                    int r1 = rgb1.R;
                    int g1 = rgb1.G;
                    int b1 = rgb1.B;
                    newImage.SetPixel(i, j, Color.FromArgb(r & r1, g & g1, b & b1));

                }
            }*/
            imageGot = newImage;
            pictureBox1.Image = imageGot;
        }

        private void twoHxtwoH()
        {
            ExtractBiggestBlob biggestBlob = new ExtractBiggestBlob();
            imageGot = new Bitmap(imageGot);
            imageGot = biggestBlob.Apply(imageGot);
            //pictureBox1.Image = imageGot;

            imageGot = new Bitmap(imageGot, new Size(200, 200));
            int imgHeight = imageGot.Height;
            int imgWidth = imageGot.Width;

            var rect = new Rectangle(0, 0, imgWidth, imgHeight);
            var data = imageGot.LockBits(rect, ImageLockMode.ReadWrite, imageGot.PixelFormat);
            var depth = Bitmap.GetPixelFormatSize(data.PixelFormat) / 8; //bytes per pixel

            var buffer = new byte[data.Width * data.Height * depth];

            //copy pixels to buffer
            Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
            ProcessTwoHxTwoH(buffer, 0, 0, data.Width, data.Height, data.Width, depth);
            /*System.Threading.Tasks.Parallel.Invoke(
                () =>
                {
                    //upper-left
                    Process(buffer, 0, 0, data.Width / 2, data.Height / 2, data.Width, depth);
                },
                () =>
                {
                    //upper-right
                    Process(buffer, data.Width / 2, 0, data.Width, data.Height / 2, data.Width, depth);
                },
                () =>
                {
                    //lower-left
                    Process(buffer, 0, data.Height / 2, data.Width / 2, data.Height, data.Width, depth);
                },
                () =>
                {
                    //lower-right
                    Process(buffer, data.Width / 2, data.Height / 2, data.Width, data.Height, data.Width, depth);
                }
            );*/

            //Copy the buffer back to image
            Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);

            imageGot.UnlockBits(data);
            /*Color blacks = Color.FromArgb(Color.Black.ToArgb());
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    if (imageGot.GetPixel(i, j) == Color.FromArgb(Color.Empty.ToArgb()))
                    {
                        imageGot.SetPixel(i, j, blacks);
                    }
                }
            }*/
            pictureBox1.Image = imageGot;
        }



        private void fillHoles()
        {
            Closing close = new Closing();
            imageGot = close.Apply(imageGot);
            imageGot = close.Apply(imageGot);
            Opening opening = new Opening();
            imageGot = opening.Apply(imageGot);
            FillHoles fillHoles = new FillHoles();
            fillHoles.MaxHoleHeight = 20;
            fillHoles.MaxHoleWidth = 20;
            fillHoles.CoupledSizeFiltering = false;
            imageGot = fillHoles.Apply(imageGot);
            pictureBox1.Image = imageGot;
        }
        void ProcessAndImages(byte[] buffer1, byte[] buffer2, int x, int y, int endx, int endy, int width, int depth1, int depth2)
        {
            for (int i = x; i < endx; i++)
            {
                for (int j = y; j < endy; j++)
                {
                    var offset1 = ((j * width) + i) * depth1;
                    var offset2 = ((j * width) + i) * depth2;
                    var b1 = buffer1[offset1 + 0];
                    var g1 = buffer1[offset1 + 1];
                    var r1 = buffer1[offset1 + 2];
                    var b = buffer2[offset1 + 0];
                    var g = buffer2[offset1 + 1];
                    var r = buffer2[offset1 + 2];
                    buffer2[offset2 + 0] = (byte) (b & b1);
                    buffer2[offset2 + 1] = (byte)(g & g1);
                    buffer2[offset2 + 2] = (byte)(r & r1);
                }

            }

        }
        void ProcessTwoHxTwoH(byte[] buffer, int x, int y, int endx, int endy, int width, int depth)
        {
            for (int i = x; i < endx; i++)
            {
                for (int j = y; j < endy; j++)
                {
                    var offset = ((j * width) + i) * depth;
                    var b = buffer[offset + 0];
                    var g = buffer[offset + 1];
                    var r = buffer[offset + 2];
                    if (!(b > 0 || g > 0 || r > 0))
                    {
                        buffer[offset + 0] = buffer[offset + 1] = buffer[offset + 2] = 0;
                    }
                }

            }
        }
        void ProcessDetectSkin(byte[] buffer, int x, int y, int endx, int endy, int width, int depth)
        {
            for (int i = x; i < endx; i++)
            {
                for (int j = y; j < endy; j++)
                {
                    var offset = ((j * width) + i) * depth;
                    var b = buffer[offset + 0];
                    var g = buffer[offset + 1];
                    var r = buffer[offset + 2];
                    int max = Math.Max((Math.Max(r, g)), b);
                    int min = Math.Min((Math.Min(r, g)), b);
                    if ((r > 95 && g > 40 && b > 20) && ((max - min) > 15) && (r > g && r > b && (r - g) > 15))
                    {
                        buffer[offset + 0] = buffer[offset + 1] = buffer[offset + 2] = 255;
                    }
                    else
                    {
                        buffer[offset + 0] = buffer[offset + 1] = buffer[offset + 2] = 0;
                    }
                }

            }

        }
        private void detectSkin()
        {
            //skin detection
            Color clr = Color.FromArgb(Color.White.ToArgb());
            Color clr1 = Color.FromArgb(Color.Black.ToArgb());
            int imgHeight = imageGot.Height;
            int imgWidth = imageGot.Width;
            String sc = "";

            var rect = new Rectangle(0, 0, imgWidth, imgHeight);
            var data = imageGot.LockBits(rect, ImageLockMode.ReadWrite, imageGot.PixelFormat);
            var depth = Bitmap.GetPixelFormatSize(data.PixelFormat) / 8; //bytes per pixel

            var buffer = new byte[data.Width * data.Height * depth];

            //copy pixels to buffer
            Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
            ProcessDetectSkin(buffer, 0, 0, data.Width, data.Height, data.Width, depth);
            /*System.Threading.Tasks.Parallel.Invoke(
                () =>
                {
                    //upper-left
                    Process(buffer, 0, 0, data.Width / 2, data.Height / 2, data.Width, depth);
                },
                () =>
                {
                    //upper-right
                    Process(buffer, data.Width / 2, 0, data.Width, data.Height / 2, data.Width, depth);
                },
                () =>
                {
                    //lower-left
                    Process(buffer, 0, data.Height / 2, data.Width / 2, data.Height, data.Width, depth);
                },
                () =>
                {
                    //lower-right
                    Process(buffer, data.Width / 2, data.Height / 2, data.Width, data.Height, data.Width, depth);
                }
            );*/

            //Copy the buffer back to image
            Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);

            imageGot.UnlockBits(data);
            /*for (int i = 0; i < imgWidth; i++)
            {

                //skinArray[i] = 0;
                for (int j = 0; j < imgHeight; j++)
                {
                    if (i == 0)
                        skinArray[j] = 0;
                    Color rgb = imageGot.GetPixel(i, j);
                    int r = rgb.R;
                    int g = rgb.G;
                    int b = rgb.B;
                    int max = Math.Max((Math.Max(r, g)), b);
                    int min = Math.Min((Math.Min(r, g)), b);
                    if ((r > 95 && g > 40 && b > 20) && ((max - min) > 15) && (r > g && r > b && (r - g) > 15))
                    {
                        imageGot.SetPixel(i, j, clr);
                        //skinArray[j]++;
                    }
                    else
                    {
                        imageGot.SetPixel(i, j, clr1);
                    }

                }
            }*/

            GrayscaleBT709 gs = new GrayscaleBT709();
            imageGot = gs.Apply(imageGot);
            Threshold th = new Threshold();
            imageGot = th.Apply(imageGot);
        }
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            
            Bitmap newFrame = new Bitmap(eventArgs.Frame, new Size(400,400));
            Bitmap ab = new Bitmap(newFrame);
            orgImage = new Bitmap(newFrame);
            pictureBox2.Image = newFrame;
            numFrames++;
            if (numFrames % 50 == 0)
            {

                imageGot = ab;
                pictureBox1.Image = newFrame;
                testing();
                
            }
        }

        private void trainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            svm();
        }

        private void recordVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDeviceForm captureDevice = new VideoCaptureDeviceForm();
            if (captureDevice.ShowDialog(this) == DialogResult.OK)
            {
                
                videoSource = captureDevice.VideoDevice;
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            var val = od.ShowDialog();
            if (val == DialogResult.OK)
            {
                orgImage = new Bitmap(od.FileName);
                orgImage = new Bitmap(orgImage, new Size(400, 400));
                imageGot = new Bitmap(orgImage);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) //train
        {
            svm();
        }

        private void button4_Click(object sender, EventArgs e) //test with static data
        {
            OpenFileDialog od = new OpenFileDialog();
            var val = od.ShowDialog();
            if (val == DialogResult.OK)
            {
                orgImage = new Bitmap(od.FileName);
                orgImage = new Bitmap(orgImage, new Size(400, 400));
                imageGot = new Bitmap(orgImage);
                //pictureBox1.Image = imageGot;
                //work on image
                testing();

            }
        }

        private void button2_Click(object sender, EventArgs e) //start video
        {
            //FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDeviceForm captureDevice = new VideoCaptureDeviceForm();
            if (captureDevice.ShowDialog(this) == DialogResult.OK)
            {

                videoSource = captureDevice.VideoDevice;
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
                videoSource.Start();
            }
        }

        private void button5_Click(object sender, EventArgs e) //train with new data
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            videoSource.SignalToStop();
            //stopwatch.Stop();
            numFrames = 0;
        }

        private void multipleImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String folderNames;
            String ss = "";
            FolderBrowserDialog fb = new FolderBrowserDialog();
            int countFiles = 0;
            var res = fb.ShowDialog();
            if (res == DialogResult.OK)
            {
                folderNames = fb.SelectedPath;
                String[] folders = Directory.GetDirectories(folderNames);
                //MessageBox.Show(folders[0]);
                foreach (String folderName in folders)
                {
                    String s = Path.GetFileName(folderName);
                    letter = s[0] - 96;
                    //MessageBox.Show(letter+"");
                    String[] files = Directory.GetFiles(folderName, "*.jpg").Union(Directory.GetFiles(folderName, "*.png")).ToArray();
                    foreach (String f in files)
                    {
                        if (noOfImages < maxNoOfImages)
                        {
                            orgImage = new Bitmap(f);
                            img[noOfImages++] = new Bitmap(orgImage, new Size(400, 400));

                            orgImage = new Bitmap(img[noOfImages - 1]);
                            imageGot = new Bitmap(orgImage);
                            doAll();
                            // pictureBox1.Image = imageGot;
                            k++;

                            ss = ss + letter + " ";
                            sss[noOfImages - 1] = sss[noOfImages - 1] + letter + " ";
                            int j = 0;
                            for (j = 0; j < 35; j++)
                            {
                                ss = ss + (j + 1) + ":" + histo1[noOfImages - 1, j] + "  ";
                                sss[noOfImages - 1] = sss[noOfImages - 1] + (j + 1) + ":" + histo1[noOfImages - 1, j] + " ";
                            }
                            ss = ss + (j + 1) + ":" + histo1[noOfImages - 1, j] + "  ";
                            sss[noOfImages - 1] = sss[noOfImages - 1] + (j + 1) + ":" + histo1[noOfImages - 1, j];
                            ss = ss + Environment.NewLine;
                        }
                        else
                        {
                            ss = ss + "Exceeded max no of Images" + Environment.NewLine;
                            break;
                        }
                    }
                }

            }
            String[] copy = new String[noOfImages];
            for(int z=0;z<noOfImages;z++)
            {
                    copy[z] = sss[z];

            }
            System.IO.File.WriteAllLines(@"D:\results\Histo\res.txt", copy);
            svm();
        }

        private void histoArray()
        {
            String st = "";
            int l = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    histo[i, j] = countEdgesForBlock(i * 33, j * 33, 33, 33);
                    histo1[k, l++] = histo[i, j];
                    st = st + histo1[k, l - 1] + " ";
                }
                //int p = 132;
                int q = 132;
                for (int j = 4; j < 6; j++)
                {
                    histo[i, j] = countEdgesForBlock(i * 33, q, 34, 34);
                    histo1[k, l++] = histo[i, j];
                    st = st + histo1[k, l - 1] + " ";
                    q = q + 34;
                }
            }
            int p = 132;
            for (int i = 4; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    histo[i, j] = countEdgesForBlock(p, j * 33, 33, 33);
                    histo1[k, l++] = histo[i, j];
                    st = st + histo1[k, l - 1] + " ";
                }

                int q = 132;
                for (int j = 4; j < 6; j++)
                {
                    histo[i, j] = countEdgesForBlock(p, q, 34, 34);
                    histo1[k, l++] = histo[i, j];
                    st = st + histo1[k, l - 1] + " ";
                    q = q + 34;
                }
                p = p + 34;
            }
            //textBox1.Text = st+"\n";
        }
        private double countEdgesForBlock(int xS, int yS, int r, int c)
        {
            int count = 0;
            double histoarr = 0.0;
            for (int i = xS; i < (xS + r); i++)
            {
                for (int j = yS; j < (yS + c); j++)
                {
                    if (imageGot.GetPixel(i, j) != Color.FromArgb(Color.Black.ToArgb()))
                    {
                        histoarr++;

                    }
                    ++count;
                }
            }
            return (histoarr / (double)(count));
        }
        void svm()
        {
            var pro = ProblemHelper.ReadProblem("res.txt");
            //var c = pro.x[0];
            //MessageBox.Show(c[0].index + "    " + c[0].value);
            model = new C_SVC(pro, KernelHelper.RadialBasisFunctionKernel(8), 32.0);
        }
    }

}
