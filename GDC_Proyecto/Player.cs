namespace GDC_Proyecto
{
    public class Player
    {
        private int player_id;
        private string nickname;

        public int Player_id { get => player_id; set => player_id = value; }

        public string Nickname { get => nickname; set => nickname = value; }

        public Player()
        {
        }

        public Player(int player_id, string nickname)
        {
            this.Player_id = player_id;
            this.Nickname = nickname;
        }
    }
}
