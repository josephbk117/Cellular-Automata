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
        const int WIDTH = 50;
        const int HEIGHT = 50;
        Bitmap bmp;
        public ConwayGameOfLife()
        {
            InitializeComponent();
            init();
            timer.Start();
        }
        void init()
        {
            bmp = new Bitmap(WIDTH, HEIGHT);
            for(int i=0;i<WIDTH;i++)
            {
                for(int j=0;j<HEIGHT;j++)
                {
                    bmp.SetPixel(i, j, Color.White);
                }
            }
            bmp.SetPixel(0, 0, Color.Black);
            bmp.SetPixel(1, 0, Color.Black);
            bmp.SetPixel(2, 1, Color.Black);
            bmp.SetPixel(0, 2, Color.Black);
            bmp.SetPixel(1, 1, Color.Black);
            bmp.SetPixel(2, 2, Color.Black);
            bmp.SetPixel(2, 3, Color.Black);
            bmp.SetPixel(2, 4, Color.Black);
            bmp.SetPixel(2, 7, Color.Black);
            bmp.SetPixel(2, 8, Color.Black);

            bmp.SetPixel(3, 2, Color.Black);
            bmp.SetPixel(5, 2, Color.Black);
            bmp.SetPixel(5, 1, Color.Black);
            bmp.SetPixel(6, 6, Color.Black);
            bmp.SetPixel(6, 8, Color.Black);
            bmp.SetPixel(7, 3, Color.Black);
            bmp.SetPixel(8, 5, Color.Black);

            bmp.SetPixel(WIDTH / 2, HEIGHT / 2, Color.Black);
            bmp.SetPixel(WIDTH / 2+1, HEIGHT / 2, Color.Black);
            bmp.SetPixel(WIDTH / 2 + 1, HEIGHT / 2-1, Color.Black);
            bmp.SetPixel(WIDTH / 2 + 2, HEIGHT / 2 - 1, Color.Black);
            pictureBox1.Image = bmp;
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
            pictureBox1.Image = null;
            pictureBox1.Image = bmp;
            
        }

        private void timer_Udate(object sender, EventArgs e)
        {
            generate();            
        }
    }
}
