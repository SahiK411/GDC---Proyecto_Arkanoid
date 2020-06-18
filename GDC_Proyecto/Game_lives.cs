using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDC_Proyecto
{
    class Game_lives
    {
        public static int lives = 3;

        public static int GameLives()
        {
            int livesRemaind = lives - 1;
            return livesRemaind;
        }
    }
}
