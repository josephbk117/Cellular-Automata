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
    public partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();
        }

        private void buttonWolfram_Click(object sender, EventArgs e)
        {
            Form f = new WolframAlpha();
            f.Show();
        }

        private void buttonConway_Click(object sender, EventArgs e)
        {
            Form f = new ConwayGameOfLife();
            f.Show();
        }
    }
}
