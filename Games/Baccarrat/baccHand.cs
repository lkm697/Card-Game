using Card_Game.Models;

namespace Card_Game.Games.Baccarrat
{
    public class baccHand
    {
        public HandResult result { get; set; }
        public Card banker1 { get; set; }
        public Card banker2 { get; set; }
        public Card banker3 { get; set; }
        public Card player1 { get; set; }
        public Card player2 { get; set; }
        public Card player3 { get; set; }


        private int bankFull = 0;
        public int bankerTotal
        {
            get
            {
                switch (bankFull)
                {
                    case var expression when bankFull >= 30:
                        return bankFull - 30;
                    case var expression when bankFull >= 20:
                        return bankFull - 20;
                    case var expression when bankFull >= 10:
                        return bankFull - 10;
                    case var expression when (bankFull >= 0 && bankFull < 10):
                        return bankFull;
                    default:
                        return -1;
                }
            }
            set
            {
                bankFull = value;
            }
        }


        private int playerFull = 0;
        public int playerTotal
        {
            get
            {
                switch (playerFull)
                {
                    case var expression when playerFull >= 30:
                        return playerFull - 30;
                    case var expression when playerFull >= 20:
                        return playerFull - 20;
                    case var expression when playerFull >= 10:
                        return playerFull - 10;
                    case var expression when (playerFull >= 0 && playerFull < 10):
                        return playerFull;
                    default:
                        return -1;
                }
            }
            set
            {
                playerFull = value;
            }
        }


    }
}
