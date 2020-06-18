using System;
using System.Drawing;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class UC_Game : UserControl
    {
        // Declarando los picture box
        private CustomPictureBox[,] CustomPictureBox;
        private Panel Scores;
        private Label Score;
        private Panel Lives;
        private Label Live;
        private PictureBox ball;
        public delegate void OnLose(object sender = null, EventArgs e = null);
        public OnLose onLose;

        public UC_Game()
        {
            InitializeComponent();

            Height = ClientSize.Height;
            Width = ClientSize.Width;
        }

        private void UC_Game_Load(object sender, EventArgs e)
        {
            // Configurando los atributos para picBox de la nave
            PictureBox.BackgroundImage = Image.FromFile("../../Img/spacecraft.png");
            PictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            PictureBox.Top = (Height - PictureBox.Height) - 100;

            // Configurando los atributos para la picBox de la pelota
            ball = new PictureBox();
            ball.Width  = 20;
            ball.Height = 20;
            ball.BackgroundImage = Image.FromFile("../../Img/ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;

            ball.Top = PictureBox.Top - ball.Height;
            ball.Left = PictureBox.Left + (PictureBox.Width / 2) - (ball.Width / 2);

            Controls.Add(ball);

            ScorePanel();
            GameLives();
            LoadTiles();
            Timer.Start();
        }

        // Metodos para iniciar el juego
        private void UC_Game_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                GameData.GameStarted = true;

        }

        private void UC_Game_OnClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                GameData.GameStarted = true;
        }

        // Metodo para el movimiento de la nave con el mouse
        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GameData.GameStarted)
            {
                if (e.X < (Width - PictureBox.Width))
                {
                    PictureBox.Left = e.X;
                    ball.Left = PictureBox.Left + (PictureBox.Width / 2) - (ball.Width / 2);
                }
            }
            else
            {
                if (e.X < (Width - PictureBox.Width))
                    PictureBox.Left = e.X;
            }
        }

        // Metodo que agergara los bloques
        private void LoadTiles()
        {
            int xAxis = 10;
            int yAxis = 5;

            int pbHeight = (int)(Height * 0.2) / yAxis;
            int pbWidth = (Width - xAxis) / xAxis;

            CustomPictureBox = new CustomPictureBox[yAxis, xAxis];

            for (int i = 0; i < yAxis; i++)
            {
                for (int j = 0; j < xAxis; j++)
                {
                    CustomPictureBox[i, j] = new CustomPictureBox();

                    if (i == 0)
                        CustomPictureBox[i, j].golpes = 2;
                    else
                        CustomPictureBox[i, j].golpes = 1;

                    CustomPictureBox[i, j].Height = pbHeight;
                    CustomPictureBox[i, j].Width = pbWidth;

                    CustomPictureBox[i, j].Left = j * pbWidth;
                    CustomPictureBox[i, j].Top = (i * pbHeight) + Scores.Height;


                    CustomPictureBox[i, j].BackgroundImage = Image.FromFile("../../Img/" + GenerateRandomNumber() + ".png");
                    CustomPictureBox[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    CustomPictureBox[i, j].Tag = "tileTag";

                    Controls.Add(CustomPictureBox[i, j]);
                }
            }
        }
        
        // Metodo que genera un numero random para las imagenes de los bloques
        private int GenerateRandomNumber()
        {
            return new Random().Next(2, 10);
        }

        // Metodo que toma el tiempo
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!GameData.GameStarted)
                return;

            ball.Left += GameData.dirX;
            ball.Top += GameData.dirY;

            ReboundBall();
        }

        // Metodo que se encarga para los rebotes de la pelota
        private void ReboundBall()
        {
            if (ball.Bottom > Height)
            {
                Timer.Stop();
                Game_lives.GameLives();
                MessageBox.Show("Ha perdido..." + "\nCuenta con " + Game_lives.lives + " vidas restantes");
                if (Game_lives.lives == 0)
                {
                    MessageBox.Show("Ha perdido...\nFin de la partida");
                }
                RepositionElements();
                               

                //Agregar puntaje a la Base de Datos
                var dt = Connection_DataBase.ExecuteQuery($"SELECT player_id FROM players WHERE nickname = '{GameData.Nickname}'");
                var dr = dt.Rows[0];
                var player_id = Convert.ToInt32(dr[0].ToString());
                Connection_DataBase.ExecuteNonQuery($"INSERT INTO scores(player_id, score)" +
                    $" VALUES({player_id}, {GameData.Puntaje})");

                GameData.GameRestart();
                onLose?.Invoke();
            }
            if (ball.Left < 0 || ball.Right > Width)
            {
                GameData.dirX = -GameData.dirX;
                return;
            }

            if (ball.Bounds.IntersectsWith(PictureBox.Bounds))
                GameData.dirY = -GameData.dirY;

            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ball.Bounds.IntersectsWith(CustomPictureBox[i, j].Bounds) && Controls.Contains(CustomPictureBox[i,j]))
                    {
                        CustomPictureBox[i, j].golpes--;

                        if (CustomPictureBox[i, j].golpes == 0)
                        {
                            Controls.Remove(CustomPictureBox[i, j]);
                            GameData.LadrillosRotos++;
                            GameData.Puntaje += (GameData.LadrillosRotos * 10) + 100;
                            Score.Text = GameData.Puntaje.ToString();
                        }
                        GameData.dirY = -GameData.dirY;

                        return;
                    }
                }
            }
        }

        private void ScorePanel()
        {
            //Instanciar Panel
            Scores = new Panel();

            //Setear Attributos del Panel
            Scores.Width = Width;
            Scores.Height = (int)(Height * 0.05);
            Scores.Top = 0;
            Scores.Left = 0;
            Scores.BackColor = Color.DarkBlue;

            //Instanciar Label
            Score = new Label();

            //Setear atributos del label
            Score.ForeColor = Color.White;
            Score.Font = new Font("Microsoft YaHei", 24F);
            Score.Text = GameData.Puntaje.ToString();
            Score.TextAlign = ContentAlignment.MiddleCenter;
            Score.Height = Scores.Height;
            Score.Width = 100;
            Score.Left = Width - 150;
            Score.Top = Scores.Top;

            //Agregar a Controls
            Scores.Controls.Add(Score);
            Controls.Add(Scores);

        }

        private void GameLives()
        {
            Lives = new Panel();

            Lives.Width = Width;
            Lives.Height = (int)(Height * 0.05);
            Lives.Top = 5;
            Lives.Left = 0;
            Lives.BackColor = Color.Transparent;

            Live = new Label();

            Live.ForeColor = Color.Gray;
            Live.Font = new Font("Microsoft YaHei", 20F);
            Live.Text = Game_lives.lives.ToString();
            Live.TextAlign = ContentAlignment.MiddleLeft;
            Live.Height = Lives.Height;
            Live.Width = 25;
            Live.Left = Width - 50;
            Live.Top = Lives.Top;

        }

        private void RepositionElements()
        {
            PictureBox.Left = (Width / 2) - (PictureBox.Width / 2);
            ball.Top = PictureBox.Top - ball.Height;
            ball.Left = PictureBox.Left + (PictureBox.Width / 2) - (ball.Width / 2);
        }
    }
}
