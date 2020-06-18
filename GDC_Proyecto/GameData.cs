namespace GDC_Proyecto
{
    public static class GameData
    {
        public static string Nickname = "";
        public static bool GameStarted = false;
        public static int dirX = 7, dirY = -dirX;
        public static int Score = 0;
        public static int BrokenBricks = 0;
        public static int lives = 3;

        public static void GameLives()
        {
            lives--;
        }
        public static void GameRestart()
        {
            GameStarted = false;
            Score = 0;
            BrokenBricks = 0;
            lives = 3;
            Nickname = "";
        }
    }
}
