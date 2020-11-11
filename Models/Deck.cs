using System;
using System.Collections.Generic;

namespace Card_Game.Models
{
    class Deck
    {
        public Queue<Card> shoe;

        public Deck()
        {
            shoe = buildDeck();
        }
        public Deck(int numberDecksInShoe)
        {
            shoe = buildDeck(numberDecksInShoe);
        }

        private Queue<Card> buildDeck(int deckCount = 1)
        {

            List<Card> tempdeck = new List<Card>(deckCount * 52);

            while (deckCount > 0)
            {
                for (int i = 1; i < 14; i++)
                {
                    Card tempHearts = new Card(i, SuitType.Hearts);
                    Card tempSpade = new Card(i, SuitType.Spades);
                    Card tempClub = new Card(i, SuitType.Spades);
                    Card tempDiamond = new Card(i, SuitType.Diamonds);

                    tempdeck.Add(tempHearts);
                    tempdeck.Add(tempSpade);
                    tempdeck.Add(tempClub);
                    tempdeck.Add(tempDiamond);
                }
                deckCount--;
            }


            Queue<Card> shuffled = shuffle(tempdeck);
            return shuffled;
        }

        private Queue<Card> shuffle(List<Card> shoe)
        {
            int n = shoe.Count - 1;
            Random rand1 = new Random();

            while (n >= 0)
            {
                int k = rand1.Next(1, shoe.Count);

                Card value = shoe[k];
                shoe[k] = shoe[n];
                shoe[n] = value;
                n--;
            }

            return new Queue<Card>(shoe);
        }

    }
}
