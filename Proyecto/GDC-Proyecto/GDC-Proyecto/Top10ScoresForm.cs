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
    public partial class Top10ScoresForm : Form
    {
        public Top10ScoresForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomeScreenForm window = new HomeScreenForm();
            window.Show();
            this.Hide();
        }
    }
}
