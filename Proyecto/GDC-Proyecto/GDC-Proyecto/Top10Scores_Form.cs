using System;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class Top10Scores_Form : Form
    {
        public Top10Scores_Form()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            using (Form1 form2 = new Form1())       
                form2.ShowDialog();
            Show();
        }
    }
}