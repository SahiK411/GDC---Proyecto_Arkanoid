﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class UC_Game : UserControl
    {
        private CustomPictureBox[,] CustomPictureBox;
        private PictureBox ball;

        public UC_Game()
        {
            InitializeComponent();
            Height = ClientSize.Height;
            Width = ClientSize.Width;
        }

        private void UC_Game_Load(object sender, EventArgs e)
        {
            // Cinfigurando los atributos para picBox de la nave
            PictureBox.BackgroundImage = Image.FromFile("../../Img/spacecraft.png");
            PictureBox.BackgroundImageLayout = ImageLayout.Stretch;

            PictureBox.Top = (Height = PictureBox.Height) + 500;

            // Configurando los atributos para la picBox de la pelota
            ball = new PictureBox();
            ball.Width = ball.Height = 20;
            ball.BackgroundImage = Image.FromFile("../../Img/ball.png");
            ball.BackgroundImageLayout = ImageLayout.Stretch;

            ball.Top = PictureBox.Top - ball.Height;
            ball.Left = PictureBox.Left + (PictureBox.Width / 2) - (ball.Width / 2);

            Controls.Add(ball);

            LoadTiles();
            Timer.Start();
        }

        private void UC_Game_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                GameData.GameStarted = true;
        }

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
                    CustomPictureBox[i, j].Top = i * pbHeight;


                    CustomPictureBox[i, j].BackgroundImage = Image.FromFile("../../Img/" + GenerateRandomNumber() + ".png");
                    CustomPictureBox[i, j].BackgroundImageLayout = ImageLayout.Stretch;

                    CustomPictureBox[i, j].Tag = "tileTag";

                    Controls.Add(CustomPictureBox[i, j]);
                }
            }
        }
        
        private int GenerateRandomNumber()
        {
            return new Random().Next(2, 10);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!GameData.GameStarted)
                return;

            ball.Left += GameData.dirX;
            ball.Top += GameData.dirY;

            ReboundBall();
        }

        private void ReboundBall()
        {
            if (ball.Bottom > Height)
                MessageBox.Show("Ha perdido...");

            if (ball.Left < 0 || ball.Right > Width)
            {
                GameData.dirX = -GameData.dirY;
                return;
            }

            if (ball.Bounds.IntersectsWith(PictureBox.Bounds))
                GameData.dirY = -GameData.dirX;

            for (int i = 4; i >= 0; i--)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ball.Bounds.IntersectsWith(CustomPictureBox[i, j].Bounds))
                    {
                        CustomPictureBox[i, j].golpes--;

                        if (CustomPictureBox[i, j].golpes == 0)
                            Controls.Remove(CustomPictureBox[i, j]);

                        GameData.dirY = -GameData.dirY;

                        return;
                    }
                }
            }
        }
    }
}
