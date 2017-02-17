using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CellularAutomata
{
    public partial class ConwayGameOfLife : Form
    {
        const int WIDTH = 225;
        const int HEIGHT = 225;
        Bitmap bmp;
        public ConwayGameOfLife()
        {
            InitializeComponent();
            init();
            timer.Start();
        }
        void init()
        {
            Random r = new Random();
            bmp = new Bitmap(WIDTH, HEIGHT);
            for(int i=0;i<WIDTH;i++)
            {
                for(int j=0;j<HEIGHT;j++)
                {
                    if (r.Next(0, 50) == 1)
                        bmp.SetPixel(i, j, Color.White);
                    else
                        bmp.SetPixel(i, j, Color.Black);
                }
            }
            
            //pictureBox1.Image = bmp;
        }
        void generate()
        {
            
            for(int i=1;i<WIDTH-1;i++)
            {
                for(int j=1;j<HEIGHT-1;j++)
                {

                    int neighbourState = 0;
                    for(int p = -1; p<=1 ;p++)
                    {
                        for(int q = -1; q<=1 ;q++)
                        {

                            //Console.WriteLine("Color at : " + (i + p) + "," + (j + q) + " = " + bmp.GetPixel(i + p, j + q));
                            if (bmp.GetPixel(i+p,j+q).R == 0)
                            {
                                //Console.WriteLine("inside neighbout loop");
                                neighbourState++;
                            }
                        }
                    }
                    //Console.WriteLine("Neighbour state= " + neighbourState);
                    bool currentCellAlive = false;
                    if (bmp.GetPixel(i, j).R == 0)
                    {
                        currentCellAlive = true;
                        neighbourState--;       //Remove the current cell state from the neighbour calculation
                    }

                    //Rules of life
                    if (currentCellAlive && neighbourState < 2) bmp.SetPixel(i, j, Color.White);
                    else if (currentCellAlive && neighbourState > 3) bmp.SetPixel(i, j, Color.White);
                    else if (!currentCellAlive && neighbourState == 3) bmp.SetPixel(i, j, Color.Black);
                    else
                        bmp.SetPixel(i, j, bmp.GetPixel(i, j));

                }
            }
            //pictureBox1.Image = null;
            //pictureBox1.Image = bmp;

            
        }

        private void timer_Udate(object sender, EventArgs e)
        {
            generate();  
            this.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /*try
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(
                   bmp,
                    new Rectangle( bmp.Width/2, bmp.Height/2, 700, 700),
                    // destination rectangle 
                    0,
                    0,           // upper-left corner of source rectangle
                    bmp.Width,       // width of source rectangle
                    bmp.Height,      // height of source rectangle
                    GraphicsUnit.Pixel);
            }
            catch { }*/
        }

        private void ConwayGameOfLife_Paint(object sender, PaintEventArgs e)
        {
            
            try
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(
                   bmp,
                    new Rectangle(0, 0, this.Bounds.Height-50, this.Bounds.Height-50),
                    // destination rectangle 
                    0,
                    0,           // upper-left corner of source rectangle
                    bmp.Width,       // width of source rectangle
                    bmp.Height,      // height of source rectangle
                    GraphicsUnit.Pixel);
            }
            catch { }
        }
    }
    
}
