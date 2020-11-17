using Card_Game.Models;
using System;
using System.Collections.Generic;

namespace Card_Game.Games.BlackJack
{
    public static class GameLogic
    {
        public static int playerCardValue = 0;
        public static int dealerCardValue = 0;
        public static Card[] dealerCards = new Card[5];
        public static Card[] playerCards = new Card[5];
        private static Queue<Card> deck = new Deck().shoe;

        public static void DealHand()
        {
            dealerCards = new Card[5];
            playerCards = new Card[5];
            playerCardValue = 0;
            dealerCardValue = 0;

            if (deck.Count < 10)
            {
                deck = new Deck().shoe;
            }

            playerCards[0] = deck.Dequeue();
            dealerCards[0] = deck.Dequeue();
            playerCards[1] = deck.Dequeue();
            dealerCards[1] = deck.Dequeue();
            updateCardVal();

        }

        public static void HitCard()
        {
            int i = Array.IndexOf(playerCards, null);
            if (i != -1)
            {
                playerCards[i] = deck.Dequeue();
                updateCardVal();
            }

        }

        public static bool playerBust()
        {
            int i = Array.IndexOf(playerCards, null);
            if (i == -1)
            {
                return true;
            }
            if (playerCardValue > 21)
            {
                return true;
            }

            return false;

        }

        public static void dealerDraw()
        {
            while (dealerCardValue <= 16)
            {
                int i = Array.IndexOf(dealerCards, null);
                if (i != -1)
                {
                    dealerCards[i] = deck.Dequeue();
                    updateCardVal();
                }
                else
                {
                    break;
                }
            }
        }

        private static void updateCardVal()
        {
            dealerCardValue = 0;
            playerCardValue = 0;
            bool dealerAce = false;
            bool playerAce = false;
            for (int i = 0; i < dealerCards.Length; i++)
            {
                if (dealerCards[i] != null)
                {
                    dealerCardValue += dealerCards[i].blackjackValue;
                    if (dealerCards[i].blackjackValue == 1 && dealerCardValue <= 11)
                    {
                        dealerCardValue += 10;
                        dealerAce = true;
                    }
                }
            }
            for (int k = 0; k < playerCards.Length; k++)
            {
                if (playerCards[k] != null)
                {
                    playerCardValue += playerCards[k].blackjackValue;
                    if (playerCards[k].blackjackValue == 1 && playerCardValue <= 11)
                    {
                        playerCardValue += 10;
                        playerAce = true;
                    }
                }
            }

            //make sure ace doesnt go over 21 with 11 value
            if (dealerAce == true && dealerCardValue > 21)
            {
                dealerCardValue -= 10;
            }
            if (playerAce == true && playerCardValue > 21)
            {
                playerCardValue -= 10;
            }


        }

    }
}
