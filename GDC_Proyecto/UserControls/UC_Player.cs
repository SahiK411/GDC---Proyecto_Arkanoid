using System;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class UC_Player : UserControl
    {
        // Declaracion de delegate
        public delegate void EventUserControl_Player(object sender, EventArgs e);
        public EventUserControl_Player OnClickButton_Ok;
        public EventUserControl_Player OnClickButton_Back;

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
                    GameData.Nickname = txtNickname.Text;
                    txtNickname.Clear();
                }
                else
                    throw new InvalidLengthException("No se pueden dejar espacios en blanco");
            }
            catch (Exception e)
            {
                if(e is InvalidLengthException)
                {
                    MessageBox.Show(e.Message, "Arkanoid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error...",
                        "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnClickButton_Back?.Invoke(this, e);
        }
    }
}
