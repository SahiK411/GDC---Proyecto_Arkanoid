using System;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 ventana = new Form1();
            ventana.Show();
            this.Hide();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            string queryUser = $"SELECT count(*) FROM player WHERE nickname = '{txtUsername.Text}'";
            
            var dt = ConnectionDB.ExecuteQuery(queryUser);
            var dr = dt.Rows[0];
            var users =  Convert.ToString(dr[0]);

            //MessageBox.Show(users);
            
            if (txtUsername.Text.Equals(""))
            {
                MessageBox.Show("No se pueden dejar este campo en vacio!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else if (users == "0")
            {
                try
                {
                    if (MessageBox.Show("Parece que este usuario no esta registrado.\n¿Desea registar un nuevo usuario?",
                        "ARKANOID", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionDB.ExecuteNonQuery($"INSERT INTO player VALUES('{txtUsername.Text}')");
                
                        MessageBox.Show("¡Usuario registrado exitosamente!", 
                            "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Algo ha ocurrido mal...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else if (users == "1")
            {
                MessageBox.Show("¡Siga adelante!", 
                    "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}