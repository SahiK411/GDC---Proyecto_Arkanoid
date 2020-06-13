namespace GDC_Proyecto
{
    class Player
    {
        public int player_id { get; set; }

        public string nickname { get; set; }

        public Player()
        {
        }

        public Player(int player_id, string nickname)
        {
            this.player_id = player_id;
            this.nickname = nickname;
        }
    }
}
