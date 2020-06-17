namespace GDC_Proyecto
{
    public static class GameData
    {
        public static string Nickname = "";
        public static bool GameStarted = false;
        public static int dirX = 7, dirY = -dirX;
        public static int CurrentScore = 0;
        public static int BrokenBricks = 0;

        public static void GameRestart()
        {
            GameStarted = false;
            CurrentScore = 0;
            BrokenBricks = 0;
            Nickname = "";
        }
    }
}
