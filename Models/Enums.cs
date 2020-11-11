using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Game.Models
{
     public enum SuitType
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }

    public enum HandResult
    {
        Banker,
        Player,
        Tie,
        Error
    }
}

