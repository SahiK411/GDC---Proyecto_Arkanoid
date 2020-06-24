using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace GDC_Proyecto
{
     public class PlayerDAO
    {
        private static void AddPlayer(string nickname)
        {
            try
            {
                // Query para insertar un jugador
                string NonQuery = $"INSERT INTO players(nickname) VALUES('{nickname}');";

                Connection_DataBase.ExecuteNonQuery(NonQuery);

                MessageBox.Show("�Jugador registrado exitosamente!",
                            "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("�Siga adelante!",
                        "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                if(e is UnableToConnectException)
                {
                    MessageBox.Show(e.Message, "Arkanoid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error...",
                        "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        // Metodo que verifica si un jugador ya existe o no
        public static void VerifyPlayer(string nickname)
        {
            try
            {
                // Query que verifica si ya existe o no un usuario
                string queryUser = $"SELECT count(*) FROM players WHERE nickname = '{nickname}'";

                var dt = Connection_DataBase.ExecuteQuery(queryUser);
                var dr = dt.Rows[0];
                var players = Convert.ToString(dr[0]);

                if (players == "0")
                {
                    try
                    {
                        if (MessageBox.Show("Parece que este usuario no esta registrado.\n�Desea registar un nuevo usuario?",
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
                        MessageBox.Show("Algo ha ocurrido mal...", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception e)
            {
                if (e is UnableToConnectException)
                {
                    MessageBox.Show(e.Message, "Arkanoid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error...",
                        "ARKANOID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
