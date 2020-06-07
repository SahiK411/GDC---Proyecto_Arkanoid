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
    public partial class GameForm : Form
    {
        private CustomPictureBox[,] CustomPictureBox;
        private int increment;
        public GameForm()
        {
            InitializeComponent();
            increment = 10;

            Height = ClientSize.Height;
            Width = ClientSize.Width;
            WindowState = FormWindowState.Maximized;
        }

        private void GameForm_KeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    SpaceCraft.Left -= increment;
                    break;
                case Keys.Right:
                    SpaceCraft.Left += increment;
                    break;
            }
        }

        private void SpaceCraft_MouseMove(object sender, MouseEventArgs e)
        {
            SpaceCraft.Left = e.X;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            SpaceCraft.BackgroundImage = Image.FromFile("../../Img/spacecraft.png");
            SpaceCraft.BackgroundImageLayout = ImageLayout.Stretch;

            SpaceCraft.Top = (Height = SpaceCraft.Height) + 500;

            LoadTiles();
        }

        private void LoadTiles()
        {
            int xAxis = 10;
            int yAxis = 3;

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
    }
}
