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
            Hide();
            using (UserForm form2 = new UserForm())       
                form2.ShowDialog();
            Show();
        }

        private void btnScores_Click(object sender, EventArgs e)
        {
            Hide();
            using (Top10Scores_Form form2 = new Top10Scores_Form())       
                form2.ShowDialog();
            Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}