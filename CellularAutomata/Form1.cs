using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CellularAutomata
{
    public partial class Form1 : Form
    {        
        Bitmap bmp;
        byte[] ruleset = new byte[8];
        const int width = 300;
        const int height = 125;
        List<Row> rowStack;

        Point mouse_offset;
        bool toggle = true;
        bool fullScreen = false;
        bool hasStarted = false;
        public Form1()
        {
            mouse_offset = new Point(0, 0);
            InitializeComponent();            
        }
        void init()
        {
            bmp = new Bitmap(width, height);
            rowStack = new List<Row>(); 
            Random rand = new Random();

            byte[] buffer = new byte[width];
            for (int i = 0; i < width; i++)
            {                
                buffer[i] = 0;
            }
            rowStack.Insert(rowStack.Count, new Row(buffer));
            timer1.Interval = 1;
            timer1.Start();
        }

        byte rulesMap(byte left, byte center, byte right)
        {
            if (left == 0 && center == 0 && right == 0)
                return ruleset[0]; 
            if (left == 0 && center == 0 && right == 1)
                return ruleset[1];
            if (left == 0 && center == 1 && right == 0)
                return ruleset[2];
            if (left == 0 && center == 1 && right == 1)
                return ruleset[3];
            if (left == 1 && center == 0 && right == 0)
                return ruleset[4];
            if (left == 1 && center == 0 && right == 1)
                return ruleset[5];
            if (left == 1 && center == 1 && right == 0)
                return ruleset[6];
            if (left == 1 && center == 1 && right == 1)
                return ruleset[7];           

            return 255;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            byte[] newRow = new byte[width];
            Row r = rowStack.ElementAt<Row>(rowStack.Count - 1);

            if (rowStack.Count == height)
                rowStack.RemoveAt(0);

            for (int i = 1; i < width-1; i++)
            {
                newRow[i] = rulesMap(r.CA[i - 1], r.CA[i], r.CA[i + 1]);                
            }
            rowStack.Insert(rowStack.Count, new Row(newRow));
            for (int i = 0; i < height; i++)
            {
                if (rowStack.Count > i)
                {
                    Row row = rowStack.ElementAt<Row>(i);
                    for (int j = 0; j < width; j++)
                    {
                        if (row.CA[j] == 0)
                            bmp.SetPixel(j, i, Color.White);
                        else
                            bmp.SetPixel(j, i, Color.Black);
                    }
                }
                else
                {
                    for (int j = 0; j < width; j++)
                    {
                        bmp.SetPixel(j, i, Color.Gray);
                    }
                }                
            }
            pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(hasStarted)
                timerToggle();
        }

        void timerToggle()
        {
            if (toggle)
            {
                timer1.Stop();
                button3.Text = "Resume";
            }
            else
            {
                timer1.Start();
                button3.Text = "Stop";
            }
            toggle = !toggle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hasStarted = true;
            rule_set_text.Text = "Rule Set Used : " + Convert.ToInt32(textBox1.Text + textBox2.Text
                + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text
                + textBox7.Text + textBox8.Text, 2);
            try
            {
                ruleset[0] = Byte.Parse(textBox1.Text.ToString());
                ruleset[1] = Byte.Parse(textBox2.Text.ToString());
                ruleset[2] = Byte.Parse(textBox3.Text.ToString());
                ruleset[3] = Byte.Parse(textBox4.Text.ToString());
                ruleset[4] = Byte.Parse(textBox5.Text.ToString());
                ruleset[5] = Byte.Parse(textBox6.Text.ToString());
                ruleset[6] = Byte.Parse(textBox7.Text.ToString());
                ruleset[7] = Byte.Parse(textBox8.Text.ToString());
                pictureBox1.Image = null;
                init();
                
            }
            catch
            {
                MessageBox.Show("No values for rule-set have been given");
            }

        }

        private void rule_set_valueChanged(object sender, EventArgs e)
        {
            if (sender.Equals(textBox1) && !(textBox1.Text == "0" || textBox1.Text == "1"))
                setDefault(textBox1);
            if (sender.Equals(textBox2) && !(textBox2.Text == "0" || textBox2.Text == "1"))
                setDefault(textBox2);
            if (sender.Equals(textBox3) && !(textBox3.Text == "0" || textBox3.Text == "1"))
                setDefault(textBox3);
            if (sender.Equals(textBox4) && !(textBox4.Text == "0" || textBox4.Text == "1"))
                setDefault(textBox4);
            if (sender.Equals(textBox5) && !(textBox5.Text == "0" || textBox5.Text == "1"))
                setDefault(textBox5);
            if (sender.Equals(textBox6) && !(textBox6.Text == "0" || textBox6.Text == "1"))
                setDefault(textBox6);
            if (sender.Equals(textBox7) && !(textBox7.Text == "0" || textBox7.Text == "1"))
                setDefault(textBox7);
            if (sender.Equals(textBox8) && !(textBox8.Text == "0" || textBox8.Text == "1"))
                setDefault(textBox8);

        }
        void setDefault(TextBox tb)
        {
            tb.Text = "1";
        }

        private void form_mover(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);
                Location = mousePos;
            }

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?", "Exit ?",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ? ", "Exit ? ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            toggleFullScreen();
        }
        void toggleFullScreen()
        {
            if (fullScreen)
                this.Bounds = Screen.PrimaryScreen.Bounds;
            else
                this.Bounds = new Rectangle(0, 0, 720, 540);
            fullScreen = !fullScreen;
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                e.Graphics.DrawImage(
                   bmp,
                    new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
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
