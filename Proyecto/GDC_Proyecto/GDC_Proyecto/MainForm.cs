using System;
using System.Windows.Forms;

namespace GDC_Proyecto
{

    public partial class MainForm : Form
    {
        // Declaracion de User controls
        private UC_Menu Menu;
        private UC_Game Game;
        private UC_Top10Scores Top10;
        private UC_Player Player;

        public MainForm()
        {
            InitializeComponent();

            // Inicializando los User Controls
            Menu = new UC_Menu();
            Game = new UC_Game();
            Top10 = new UC_Top10Scores();
            Player = new UC_Player();

            // Definiendo el tamano del Form
            WindowState = FormWindowState.Maximized;
            Height = Screen.PrimaryScreen.Bounds.Height;
            Width = Screen.PrimaryScreen.Bounds.Width;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Definiendo el tamano del User Control del Menu
            Menu.Dock = DockStyle.Fill;
            Menu.Width = Width;
            Menu.Height = Height;

            // Definiendo el tamano del User Control del Juego
            Game.Dock = DockStyle.Fill;
            Game.Width = Width;
            Game.Height = Height;

            // Definiendo el tamano del User Control de los 10 mejores puntajes
            Top10.Dock = DockStyle.Fill;
            Top10.Width = Width;
            Top10.Height = Height;

            // Definiendo el tamano del User Control del Jugador
            Player.Dock = DockStyle.Fill;
            Player.Width = Width;
            Player.Height = Height;

            // Anadiendo Controles de User Controls
            Controls.Add(Game);
            Game.Hide();

            Controls.Add(Top10);
            Top10.Hide();

            Controls.Add(Player);
            Player.Hide();

            Controls.Add(Menu);

            // Anadiendo funcionalidades de los botones
            Menu.OnClickButton_Play += OnCLickToUserControl_Player;
            Menu.OnClickButton_ViewScores += OnCLickToUserControl_Top10;
            Top10.OnClickButton_Back += OnCLickToUserControl_Menu;
            Player.OnClickButton_Ok += OnCLickToUserControl_Game;
            Player.OnClickButton_Back += OnCLickToUserControl_Menu;
        }

        // Muestra el User Control del Juego
        private void OnCLickToUserControl_Game(object sender, EventArgs e)
        {
            Menu.Hide();
            Top10.Hide();
            Player.Hide();
            Game.Show();
        }

        // Muestra el User Control para ver los 10 mejores puntajes
        private void OnCLickToUserControl_Top10(object sender, EventArgs e)
        {
            Menu.Hide();
            Game.Hide();
            Player.Hide();
            Top10.Show();
        }

        // Muestra el User Control cuando se este registrando un jugasdor
        private void OnCLickToUserControl_Player(object sender, EventArgs e)
        {
            Menu.Hide();
            Top10.Hide();
            Game.Hide();
            Player.Show();
        }

        // Muestra el User Control cuando se desea mostrar el menu principal
        private void OnCLickToUserControl_Menu(object sender, EventArgs e)
        {
            Top10.Hide();
            Game.Hide();
            Player.Hide();
            Menu.Show();
        }

        // Evento que pregunta al Usuario si desea salir de la aplicacion
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir del juego?",
                "ARKANOID", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
