using System;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class UC_Top10Scores : UserControl
    {
        // Declaracion de delegate
        public delegate void EventUserControl_Menu(object sender, EventArgs e);
        public EventUserControl_Menu OnClickButton_Back;

        public UC_Top10Scores()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnClickButton_Back?.Invoke(this, e);
        }
    }
}
