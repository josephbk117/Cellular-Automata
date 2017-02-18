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
        public Point currentPoint = new Point();
        public Point prevPoint = new Point();
        public Graphics g;
        Bitmap surface;
        Graphics graph;


        const int WIDTH = 50;
        const int HEIGHT = 50;
        Bitmap bmp;
        bool canSim = false;

        PaintEventArgs pe;
        public ConwayGameOfLife()
        {
            InitializeComponent();
            g = panel.CreateGraphics();
            surface = new Bitmap(100, 100);
            graph = Graphics.FromImage(surface);
            //panel.BackgroundImage = surface;
           // panel.BackgroundImageLayout = ImageLayout.Zoom;
           
        }
       
           
        void generate()
        {
            
            for(int i=1;i<surface.Width-1;i++)
            {
                for(int j=1;j<surface.Height-1;j++)
                {

                    int neighbourState = 0;
                    for(int p = -1; p<=1 ;p++)
                    {
                        for(int q = -1; q<=1 ;q++)
                        {                            
                            if (surface.GetPixel(i+p,j+q).R == 0)
                            {                                
                                neighbourState++;
                            }
                        }
                    }
                    
                    bool currentCellAlive = false;
                    if (surface.GetPixel(i, j).R == 0)
                    {
                        currentCellAlive = true;
                        neighbourState--;       //Remove the current cell state from the neighbour calculation
                    }

                    //Rules of life
                    if (currentCellAlive && neighbourState < 2) surface.SetPixel(i, j, Color.White);
                    else if (currentCellAlive && neighbourState > 3) surface.SetPixel(i, j, Color.White);
                    else if (!currentCellAlive && neighbourState == 3) surface.SetPixel(i, j, Color.Black);
                    else
                        surface.SetPixel(i, j, surface.GetPixel(i, j));

                }
            }
           
        }

        private void timer_Udate(object sender, EventArgs e)
        {
            if (canSim)
            {
                generate();                
                panel.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void ConwayGameOfLife_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            canSim = true;
        }

        private void ConwayGameOfLife_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int xPos = e.Location.X / 6;
                int yPos = e.Location.Y/ 4;

                currentPoint = new Point(xPos, yPos);
                graph.DrawLine(new Pen(Color.Black,2f), prevPoint, currentPoint);
                prevPoint = currentPoint;
                panel.Invalidate();
            }
            else if(e.Button == MouseButtons.Right)
            {
                int xPos = e.Location.X / 6;
                int yPos = e.Location.Y / 4;

                currentPoint = new Point(xPos, yPos);
                graph.DrawLine(new Pen(Color.White, 2f), prevPoint, currentPoint);
                prevPoint = currentPoint;
                panel.Invalidate();
            }
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(
                   surface,
                    new Rectangle(0, 0, panel.Width, panel.Height),
                    // destination rectangle 
                    0,
                    0,           // upper-left corner of source rectangle
                    surface.Width,       // width of source rectangle
                    surface.Height,      // height of source rectangle
                    GraphicsUnit.Pixel);
            }
            catch { }

        }
    }
    
}
