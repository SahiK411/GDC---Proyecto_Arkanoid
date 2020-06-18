using System;
using System.Drawing;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    public partial class UC_Top10Scores : UserControl
    {
        // Declaracion de delegate
        public delegate void EventUserControl_Menu(object sender, EventArgs e);
        public EventUserControl_Menu OnClickButton_Back;
        private Label[,] Top10 = new Label[10,2];

        public UC_Top10Scores()
        {
            InitializeComponent();
            refreshData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            OnClickButton_Back?.Invoke(this, e);
        }

        private void refreshData()
        {
            var dt = Connection_DataBase.ExecuteQuery("SELECT player_id FROM scores ORDER BY score DESC");
            var st = Connection_DataBase.ExecuteQuery("SELECT score FROM scores ORDER BY score DESC");
            if(dt.Rows.Count > 0)
            {
                if(dt.Rows.Count < 10)
                {
                    for(int i = 0; i < dt.Rows.Count; i++)
                    {
                        //Adding Nicknames to the UserControl
                        var dr = dt.Rows[i];
                        var player_id = dr[0];
                        var tempDT = Connection_DataBase.ExecuteQuery($"SELECT nickname FROM players " +
                            $"WHERE player_id = {player_id}");
                        dr = tempDT.Rows[0];
                        var nickname = dr[0].ToString();

                        Top10[i, 0] = new Label();
                        Top10[i, 0].Text = nickname;
                        Top10[i, 0].Font = new Font("Microsoft YaHei", 20F);
                        Top10[i, 0].TextAlign = ContentAlignment.MiddleCenter;
                        Top10[i, 0].Dock = DockStyle.Fill;
                        tableLayoutPanel1.Controls.Add(Top10[i, 0],2, i+2);

                        //Adding Scores to the UserControl
                        dr = st.Rows[i];
                        var shownScore = dr[0].ToString();
                        
                        Top10[i, 1] = new Label();
                        Top10[i, 1].Text = shownScore;
                        Top10[i, 1].Font = new Font("Microsoft YaHei", 20F);
                        Top10[i, 1].TextAlign = ContentAlignment.MiddleCenter;
                        Top10[i, 1].Dock = DockStyle.Fill;
                        tableLayoutPanel1.Controls.Add(Top10[i, 1], 4, i + 2);
                    }
                    for(int i = dt.Rows.Count; i < 10; i++)
                    {
                        //Filling out unused spaces
                        Top10[i, 0] = new Label();
                        Top10[i, 0].Text = "-----";
                        Top10[i, 0].Font = new Font("Microsoft YaHei", 16F);
                        Top10[i, 0].TextAlign = ContentAlignment.MiddleCenter;
                        Top10[i, 0].Dock = DockStyle.Fill;
                        tableLayoutPanel1.Controls.Add(Top10[i, 0], 2, i + 2);

                        Top10[i, 1] = new Label();
                        Top10[i, 1].Text = "--------";
                        Top10[i, 1].Font = new Font("Microsoft YaHei", 16F);
                        Top10[i, 1].TextAlign = ContentAlignment.MiddleCenter;
                        Top10[i, 1].Dock = DockStyle.Fill;
                        tableLayoutPanel1.Controls.Add(Top10[i, 1], 4, i + 2);
                    }
                }
                else
                {
                    for (int i = 0; i < 10; i++)
                    {
                        //Adding Nicknames to User Control
                        var dr = dt.Rows[i];
                        var player_id = dr[0];
                        var tempDT = Connection_DataBase.ExecuteQuery($"SELECT nickname FROM players " +
                            $"WHERE player_id = {player_id}");
                        dr = tempDT.Rows[0];
                        var nickname = dr[0].ToString();

                        Top10[i, 0] = new Label();
                        Top10[i, 0].Text = nickname;
                        Top10[i, 0].Font = new Font("Microsoft YaHei", 20F);
                        Top10[i, 0].TextAlign = ContentAlignment.MiddleCenter;
                        Top10[i, 0].Dock = DockStyle.Fill;
                        tableLayoutPanel1.Controls.Add(Top10[i, 0], 2, i + 2);

                        //Adding Scores to User Control
                        dr = st.Rows[i];
                        var shownScore = dr[0].ToString();

                        Top10[i, 1] = new Label();
                        Top10[i, 1].Text = shownScore;
                        Top10[i, 1].Font = new Font("Microsoft YaHei", 20F);
                        Top10[i, 1].TextAlign = ContentAlignment.MiddleCenter;
                        Top10[i, 1].Dock = DockStyle.Fill;
                        tableLayoutPanel1.Controls.Add(Top10[i, 1], 4, i + 2);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    Top10[i, 0] = new Label();
                    Top10[i, 0].Text = "-----";
                    Top10[i, 0].Font = new Font("Microsoft YaHei", 16F);
                    Top10[i, 0].TextAlign = ContentAlignment.MiddleCenter;
                    Top10[i, 0].Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(Top10[i, 0], 2, i + 2);

                    Top10[i, 1] = new Label();
                    Top10[i, 1].Text = "--------";
                    Top10[i, 1].Font = new Font("Microsoft YaHei", 16F);
                    Top10[i, 1].TextAlign = ContentAlignment.MiddleCenter;
                    Top10[i, 1].Dock = DockStyle.Fill;
                    tableLayoutPanel1.Controls.Add(Top10[i, 1], 4, i + 2);
                }
            }
        }
    }
}
