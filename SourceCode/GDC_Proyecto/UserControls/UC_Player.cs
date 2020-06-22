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
            try
            {
                RegisterPlayer(e);
            }
            catch (Exception ex)
            {
                if (ex is InvalidLengthException || ex is InvalidSymbolsException)
                {
                    MessageBox.Show(ex.Message, "Arkanoid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error...",
                        "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RegisterPlayer(EventArgs e)
        {
            try
            {
                if (txtNickname.Text.Length >= 1)
                {
                    if (txtNickname.Text.Length <= 15)
                    {
                        if (!txtNickname.Text.Contains("#") && !txtNickname.Text.Contains("&") &&
                            !txtNickname.Text.Contains(";"))
                        {
                            PlayerDAO.VerifyPlayer(txtNickname.Text);
                            GameData.Nickname = txtNickname.Text;
                            txtNickname.Clear();
                            OnClickButton_Ok?.Invoke(this, e);
                        }
                        else
                        {
                            throw new InvalidSymbolsException("Nombre de Usuario contiene caracteres invalidos.");
                        }
                    }
                    else
                        throw new InvalidLengthException("Nombre de usuario excede tamaño establecido");
                }
                else
                    throw new InvalidLengthException("No se pueden dejar espacios en blanco");
            }
            catch (Exception ex)
            {
                if (ex is InvalidLengthException || ex is InvalidSymbolsException)
                {
                    MessageBox.Show(ex.Message, "Arkanoid", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
