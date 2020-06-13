using System;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class UC_Menu : UserControl
    {
        public delegate void EventUserControl_Menu(object sender, EventArgs e);
        public EventUserControl_Menu OnClickButton_Play;
        public EventUserControl_Menu OnClickButton_ViewScores;

        public UC_Menu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            OnClickButton_Play?.Invoke(this, e);
        }

        private void btnScores_Click(object sender, EventArgs e)
        {
            OnClickButton_ViewScores?.Invoke(this, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir del juego?",
                "ARKANOID", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
