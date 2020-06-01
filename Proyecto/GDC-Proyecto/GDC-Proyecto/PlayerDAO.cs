using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GDC_Proyecto
{
    class PlayerDAO
    {
        public static List<Player> GetList()
        {
            string Query = "SELECT * FROM players";

            DataTable dt = ConnectionDB.ExecuteQuery(Query);

            List<Player> PlayersList = new List<Player>();
            foreach (DataRow row in dt.Rows)
            {
                Player player = new Player();
                player.player_id = Convert.ToInt32(row[0].ToString());
                player.nickname = row[1].ToString();

                PlayersList.Add(player);
            }
            return PlayersList;
        }

        private static void AddPlayer(string nickname)
        {
            string NonQuery = String.Format(
                $"INSERT INTO players(nickname) VALUES('{nickname}');");

            ConnectionDB.ExecuteNonQuery(NonQuery);

            MessageBox.Show("¡Jugador registrado exitosamente!",
                            "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show("¡Siga adelante!",
                    "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void VerifyPlayer(string nickname)
        {
            string queryUser = $"SELECT count(*) FROM players WHERE nickname = '{nickname}'";

            var dt = ConnectionDB.ExecuteQuery(queryUser);
            var dr = dt.Rows[0];
            var players = Convert.ToString(dr[0]);

            if (players == "0")
            {
                try
                {
                    if (MessageBox.Show("Parece que este usuario no esta registrado.\n¿Desea registar un nuevo usuario?",
                        "ARKANOID", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        AddPlayer(nickname);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo ha ocurrido mal...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("¡Siga adelante!",
                    "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
