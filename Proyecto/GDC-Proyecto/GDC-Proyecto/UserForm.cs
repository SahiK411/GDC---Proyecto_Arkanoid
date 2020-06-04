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
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNickname.Text.Length >= 1)
                {
                    PlayerDAO.VerifyPlayer(txtNickname.Text);

                    txtNickname.Clear();

                    GameForm window = new GameForm();
                    window.Show();
                    this.Hide();
                }
                else
                    throw new InvalidLengthException("No se pueden dejar espacios en blanco");
            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error...",
                    "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HomeScreenForm window = new HomeScreenForm();
            window.Show();
            this.Hide();
        }
    }
}
