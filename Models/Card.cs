namespace Card_Game.Models
{
    public class Card
    {
        private int _faceValue;
        public SuitType Suit { get; set; }
        public string imageSourceString { get; set; }


        public int blackjackValue
        {
            get
            {
                if (_faceValue > 10)
                {
                    return 10;
                }
                return _faceValue;
            }
            private set { }


        }

        public Card(int i, SuitType suit)
        {

            _faceValue = i;
            Suit = suit;
            switch (suit)
            {
                case SuitType.Spades:
                    imageSourceString = $@"/images/card deck/{i}-spades.png";
                    break;
                case SuitType.Hearts:
                    imageSourceString = $@"/images/card deck/{i}-hearts.png";
                    break;
                case SuitType.Diamonds:
                    imageSourceString = $@"/images/card deck/{i}-diamonds.png";
                    break;
                case SuitType.Clubs:
                    imageSourceString = $@"/images/card deck/{i}-clubs.png";
                    break;
                default:

                    imageSourceString = $@"/images/card deck/joker-1.png";
                    break;
            }
        }

        public Card()
        {
            _faceValue = 0;
            Suit = SuitType.Clubs;
            imageSourceString = $@"/images/card deck/back-blue-2.png";
        }

        public static bool operator >(Card c1, Card c2) => c1._faceValue > c2._faceValue;
        public static bool operator <(Card c1, Card c2) => c1._faceValue < c2._faceValue;
        public static bool operator >=(Card c1, Card c2) => c1._faceValue >= c2._faceValue;
        public static bool operator <=(Card c1, Card c2) => c1._faceValue <= c2._faceValue;
    }
}
