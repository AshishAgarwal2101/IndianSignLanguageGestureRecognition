using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using libsvm;

namespace IndianSignLanguageGestureRecognition
{
    public partial class Form1 : Form
    {
        Bitmap orgImage, imageGot;
        static int maxNoOfImages = 130;
        Bitmap[] img= new Bitmap[maxNoOfImages];
        Bitmap[] gotImages = new Bitmap[maxNoOfImages];
        static int orgImWidth = 400, orgImHeight = 400;
        double[,] histo = new double[6, 6];
        int[] skinArray = new int[orgImWidth];
        double[,] histo1 = new double[maxNoOfImages, 36];
        int[,] totHisto = new int[maxNoOfImages, 36];
        String s = "";
        String[] sss = new String[maxNoOfImages];
        int noOfImages = 0, k, letter;
        C_SVC model;

        public Form1()
        {
            InitializeComponent();
        }

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            var val = od.ShowDialog();
            if(val == DialogResult.OK)
            {
                orgImage = new Bitmap(od.FileName);
                orgImage = new Bitmap(orgImage, new Size(400, 400));
                orgImHeight = 400;
                orgImWidth = 400;
                imageGot = new Bitmap(orgImage);
                pictureBox1.Image = imageGot;
                //work on image
                detectSkin();
                fillHoles();
                extractLargestBlob();
                andImages();
                twoHxtwoH();
                edgeDetect();
                //making svm_node
                svm_node[] svmNode = { nodeMaking() };
                var pred_y = model.Predict(svmNode);
                MessageBox.Show(pred_y+"");

            }
        }

        private svm_node nodeMaking()
        {
            String st = "";
            int l = 0;
            svm_node svmNode = new svm_node();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double value = countEdgesForBlock(i * 33, j * 33, 33, 33);
                    svmNode.index = l++;
                    svmNode.value = value;                    
                }
                int q = 132;
                for (int j = 4; j < 6; j++)
                {
                    double value = countEdgesForBlock(i * 33, q, 34, 34);
                    svmNode.index = l++;
                    svmNode.value = value;
                    q = q + 34;
                }
            }
            int p = 132;
            for (int i = 4; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double value = countEdgesForBlock(p, j * 33, 33, 33);
                    svmNode.index = l++;
                    svmNode.value = value;
                }

                int q = 132;
                for (int j = 4; j < 6; j++)
                {
                    double value = countEdgesForBlock(p, q, 34, 34);
                    svmNode.index = l++;
                    svmNode.value = value;
                    q = q + 34;
                }
                p = p + 34;
            }
            return svmNode;
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
            Directory.CreateDirectory(@"E:\results\Bitmaps\" + (char)(letter + 64));
            gotImages[k].Save(@"E:\results\Bitmaps\"+(char)(letter+64)+"\\" + k +".jpg");
            svm();
            
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
            

            int[] der1 = new int[399];
            int[] der2 = new int[398];
            Color clr = Color.FromArgb(Color.White.ToArgb());
            Color clr1 = Color.FromArgb(Color.Black.ToArgb());
            int imgHeight = imageGot.Height;
            int imgWidth = imageGot.Width;
            for(int i=0; i<imgWidth; i++)
            {
                for(int j=0; j<imgHeight; j++)
                {
                    Color rgb = imageGot.GetPixel(i, j);
                    if (rgb == clr)
                        skinArray[j]++;
                }
            }
            //palm extraction(without band) ------------------
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

            }
            //MessageBox.Show(skinArray[pos-1]+" "+skinArray[pos]+" "+skinArray[pos+1]+" "+skinArray[pos+2]+" "+skinArray[pos+3]+" \r\n"+der1[pos-1]+" "+der1[pos]+" "+der1[pos+1]+" "+der1[pos+2]+" \r\n"+der2[pos-1]+" "+der2[pos]+" "+der2[pos+1]);
            //MessageBox.Show(sa);
            imageGot = new Bitmap(imageGot); 
            for (int i = 0; i < imgWidth; i++)
            {
                //skinArray[i] = 0;
                for (int j = 0; j <= pos; j++)
                {
                    imageGot.SetPixel(i, j, clr1);
                }
            }
            //palm extraction ends ---------
            pictureBox1.Image = imageGot;
        }

        private void andImages()
        {
            imageGot = new Bitmap(imageGot);
            Bitmap newImage = new Bitmap(orgImage);
            //pictureBox1.Image = orgImage;
            //AND orgImage and imageGot
            for (int i = 0; i < orgImWidth; i++)
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
            }
            imageGot = newImage;
            pictureBox1.Image = imageGot;
        }

        private void twoHxtwoH()
        {
            ExtractBiggestBlob biggestBlob = new ExtractBiggestBlob();
            imageGot = new Bitmap(imageGot);
            imageGot = biggestBlob.Apply(imageGot);
            //pictureBox1.Image = imageGot;
            Color blacks = Color.FromArgb(Color.Black.ToArgb());
            imageGot = new Bitmap(imageGot, new Size(200, 200));
            for (int i = 0; i < 200; i++)
            {
                for (int j = 0; j < 200; j++)
                {
                    if (imageGot.GetPixel(i, j) == Color.FromArgb(Color.Empty.ToArgb()))
                    {
                        imageGot.SetPixel(i, j, blacks);
                    }
                }
            }
            pictureBox1.Image = imageGot;
        }

        

        private void fillHoles()
        {
            Closing close = new Closing();
            imageGot = close.Apply(imageGot);
            imageGot = close.Apply(imageGot);
            Opening opening = new Opening();
            imageGot = opening.Apply(imageGot);
            /*FillHoles fillHoles = new FillHoles();
            fillHoles.MaxHoleHeight = 20;
            fillHoles.MaxHoleWidth = 20;
            fillHoles.CoupledSizeFiltering = false;
            imageGot = fillHoles.Apply(imageGot);*/
            pictureBox1.Image = imageGot;
        }

        private void detectSkin()
        {
            //skin detection
            Color clr = Color.FromArgb(Color.White.ToArgb());
            Color clr1 = Color.FromArgb(Color.Black.ToArgb());
            int imgHeight = imageGot.Height;
            int imgWidth = imageGot.Width;
            String sc = "";
            for (int i = 0; i < imgWidth; i++)
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
            }
            
            GrayscaleBT709 gs = new GrayscaleBT709();
            imageGot = gs.Apply(imageGot);
            Threshold th = new Threshold();
            imageGot = th.Apply(imageGot);
            pictureBox1.Image = imageGot;
            textBox1.Text = sc;
        }

        private void multipleImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            String folderNames;
            String ss = "";
            FolderBrowserDialog fb = new FolderBrowserDialog();
            
            var res = fb.ShowDialog();
            if(res== DialogResult.OK)
            {
                folderNames = fb.SelectedPath;
                String [] folders = Directory.GetDirectories(folderNames);
                //MessageBox.Show(folders[0]);
                foreach(String folderName in folders)
                {
                    String s = Path.GetFileName(folderName);
                    letter = s[0]-64;
                    //MessageBox.Show(letter+"");
                    String[] files = Directory.GetFiles(folderName, "*.jpg").Union(Directory.GetFiles(folderName, "*.png")).ToArray();
                    foreach (String f in files)
                    {
                        if (noOfImages < maxNoOfImages)
                        {
                            orgImage = new Bitmap(f);
                            img[noOfImages++] = new Bitmap(orgImage, new Size(400, 400));

                            orgImage = new Bitmap(img[noOfImages-1]);
                            imageGot = new Bitmap(orgImage);
                            doAll();
                            // pictureBox1.Image = imageGot;
                            k++;

                            ss = ss + letter+" ";
                            sss[noOfImages-1] = sss[noOfImages-1] + letter + " ";
                            for (int j = 0; j < 36; j++)
                            {
                                ss = ss + (j + 1) + ":" + histo1[noOfImages-1, j] + "  ";
                                sss[noOfImages-1] = sss[noOfImages-1] + (j + 1) + ":" + histo1[noOfImages-1, j] + ", ";
                            }
                            ss = ss + "\r\n";
                        }
                        else
                        {
                            ss = ss + "Exceeded max no of Images" + "\r\n";
                            break;
                        }
                    }
                }
                
            }
            textBox1.Text = ss;
            System.IO.File.WriteAllLines(@"E:\results\Histo\res.problem", sss);
        }

        private void histoArray()
        {
            String st = "";
            int l = 0;
            for(int i=0; i<4; i++)
            {
                for(int j=0; j<4; j++)
                {
                    histo[i, j] = countEdgesForBlock(i * 33, j * 33, 33, 33);
                    histo1[k, l++] = histo[i, j];
                    st = st + histo1[k, l-1]+" ";
                }
                //int p = 132;
                int q = 132;
                for (int j = 4; j < 6; j++)
                {
                    histo[i, j] = countEdgesForBlock(i * 33, q, 34, 34);
                    histo1[k, l++] = histo[i, j];
                    st = st + histo1[k, l-1] + " ";
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
                    st = st + histo1[k, l-1] + " ";
                }
                
                int q = 132;
                for (int j = 4; j < 6; j++)
                {
                    histo[i, j] = countEdgesForBlock(p, q, 34, 34);
                    histo1[k, l++] = histo[i, j];
                    st = st + histo1[k, l-1] + " ";
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
            return (histoarr/(double)count);
        }
        void svm()
        {
            var pro = ProblemHelper.ReadProblem(@"E:\results\Histo\res.problem");
            model = new C_SVC(pro, KernelHelper.LinearKernel(), 1.0);
        }
    }

}
