using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            UserForm ventana = new UserForm();
            ventana.Show();
            this.Hide();
        }

        private void btnScores_Click(object sender, EventArgs e)
        {
            Top10Scores_Form ventana = new Top10Scores_Form();
            ventana.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}