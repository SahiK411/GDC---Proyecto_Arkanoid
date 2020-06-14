using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GDC_Proyecto
{
     public class PlayerDAO
    {
        public static List<Player> GetList()
        {
            string Query = "SELECT * FROM players";

            DataTable dt = Connection_DataBase.ExecuteQuery(Query);

            List<Player> PlayersList = new List<Player>();
            foreach (DataRow row in dt.Rows)
            {
                Player player = new Player();
                player.Player_id = Convert.ToInt32(row[0].ToString());
                player.Nickname = row[1].ToString();

                PlayersList.Add(player);
            }
            return PlayersList;
        }

        private static void AddPlayer(string nickname)
        {
            string NonQuery = $"INSERT INTO players(nickname) VALUES('{nickname}');";

            Connection_DataBase.ExecuteNonQuery(NonQuery);

            MessageBox.Show("¡Jugador registrado exitosamente!",
                            "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);

            MessageBox.Show("¡Siga adelante!",
                    "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void VerifyPlayer(string nickname)
        {
            string queryUser = $"SELECT count(*) FROM players WHERE nickname = '{nickname}'";

            var dt = Connection_DataBase.ExecuteQuery(queryUser);
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
                    else
                        MessageBox.Show("No se guardara un registro de la partida a realizar.", "ARKANOID", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("Algo ha ocurrido mal...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
