namespace GDC_Proyecto
{
    public static class GameData
    {
        public static string Nickname = "";
        public static bool GameStarted = false;
        public static int dirX = 7, dirY = -dirX;
        public static int Puntaje = 0;
        public static int LadrillosRotos = 0;

        public static void GameRestart()
        {
            GameStarted = false;
            Puntaje = 0;
            LadrillosRotos = 0;
            Nickname = "";
        }
    }
}
