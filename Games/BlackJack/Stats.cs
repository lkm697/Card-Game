﻿namespace Card_Game.Games.BlackJack
{
    static class Stats
    {
        public static int pWins { get; set; }
        public static int pLosses { get; set; }
        static Stats()
        {
            pWins = 0;
            pLosses = 0;
        }
    }
}
