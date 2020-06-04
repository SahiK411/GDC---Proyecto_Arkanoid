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
    public partial class GameForm : Form
    {
        private int increment;
        public GameForm()
        {
            InitializeComponent();
            increment = 10;
            WindowState = FormWindowState.Maximized;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void GameForm_KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    SpaceCraft.Left -= increment;
                    break;
                case Keys.Right:
                    SpaceCraft.Left += increment;
                    break;
            }
        }

        private void SpaceCraft_MouseMove(object sender, MouseEventArgs e)
        {
            SpaceCraft.Left = e.X;
        }
    }
}
