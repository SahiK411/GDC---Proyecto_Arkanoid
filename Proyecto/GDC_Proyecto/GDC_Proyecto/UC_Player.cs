using System;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class UC_Player : UserControl
    {
        // Declaracion de delegate
        public delegate void EventUserControl_Player(object sender, EventArgs e);
        public EventUserControl_Player OnClickButton_Ok;

        public UC_Player()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            RegisterPlayer();

            OnClickButton_Ok?.Invoke(this, e);
        }

        private void RegisterPlayer()
        {
            try
            {
                if (txtNickname.Text.Length >= 1)
                {
                    PlayerDAO.VerifyPlayer(txtNickname.Text);

                    txtNickname.Clear();
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
    }
}
