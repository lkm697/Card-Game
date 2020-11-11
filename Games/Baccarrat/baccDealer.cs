using Card_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game.Games.Baccarrat
{
    public static class baccDealer
    {

        private static Queue<Card> mainShoe;
        public static Queue<baccHand> completedHands = buildRound();
        public static Card[] burnCards;
        private static int shoeSize;

        public static Queue<baccHand> buildRound(int decksInShoe = 8)
        {
            shoeSize = decksInShoe;
            mainShoe = new Deck(shoeSize).shoe;
            completedHands = new Queue<baccHand>();
            burnCard();
            while (mainShoe.Count >= 8)
            {
                completedHands.Enqueue(theHand());
            }

            return completedHands;
        }

        private static void burnCard()
        {

            int burn = mainShoe.Peek().faceValue;
            if (burn > 10)
            {
                burn = 10;
            }

            burnCards = new Card[burn + 1];
            burnCards[0] =  mainShoe.Dequeue(); //burn card
            // cards to be burned
            for (int i = 1; i <= burn; i++)
            {
                burnCards[i] = mainShoe.Dequeue();
            }
        }

        private static baccHand theHand()
        {

            var currentHand = new baccHand();
            var player1 = mainShoe.Dequeue();
            var banker1 = mainShoe.Dequeue();
            var player2 = mainShoe.Dequeue();
            var banker2 = mainShoe.Dequeue();

            Card banker3 = new Card();
            Card player3 = new Card();
            

            currentHand.bankerTotal = banker1.faceValue + banker2.faceValue;
            currentHand.playerTotal = player1.faceValue + player2.faceValue;


            // check natural 9
            if (currentHand.playerTotal == 9 || currentHand.bankerTotal == 9)
            {

                currentHand.banker1 = banker1;
                currentHand.banker2 = banker2;
                currentHand.banker3 = banker3;
                currentHand.player1 = player1;
                currentHand.player2 = player2;
                currentHand.player3 = player3;

                if (currentHand.playerTotal == currentHand.bankerTotal)
                {
                    //return tie
                    currentHand.result = HandResult.Tie;
                }
                if (currentHand.playerTotal == 9 && currentHand.playerTotal > currentHand.bankerTotal)
                {
                    // player win natural 9
                    currentHand.result = HandResult.Player;
                }
                if (currentHand.bankerTotal == 9 && currentHand.bankerTotal > currentHand.playerTotal)
                {
                    // banker win natural 9
                    currentHand.result = HandResult.Banker;
                }
                currentHand.playerTotal = currentHand.playerTotal;
                currentHand.bankerTotal = currentHand.bankerTotal;

                return currentHand;
            }

            // natural 8
            if (currentHand.playerTotal == 8 || currentHand.bankerTotal == 8)
            {
                currentHand.banker1 = banker1;
                currentHand.banker2 = banker2;
                currentHand.banker3 = banker3;
                currentHand.player1 = player1;
                currentHand.player2 = player2;
                currentHand.player3 = player3;

                if (currentHand.playerTotal == currentHand.bankerTotal)
                {
                    //return tie
                    currentHand.result = HandResult.Tie;
                }
                if (currentHand.playerTotal == 8 && currentHand.playerTotal > currentHand.bankerTotal)
                {
                    // player win natural 8
                    currentHand.result = HandResult.Player;
                }
                if (currentHand.bankerTotal == 8 && currentHand.bankerTotal > currentHand.playerTotal)
                {
                    // banker win natural 8
                    currentHand.result = HandResult.Banker;
                }

                currentHand.playerTotal = currentHand.playerTotal;
                currentHand.bankerTotal = currentHand.bankerTotal;

                return currentHand;
            }

            //player 6 or 7 no draw or check

            //player 0 - 5 draw

            if (currentHand.playerTotal <= 5)
            {
                player3 = mainShoe.Dequeue();

                currentHand.playerTotal += player3.faceValue;
            }


            //banker draws
            //no draw on 7
            //check  win
            if (currentHand.bankerTotal == 7)
            {
                currentHand.banker1 = banker1;
                currentHand.banker2 = banker2;
                currentHand.banker3 = banker3;

                currentHand.player1 = player1;
                currentHand.player2 = player2;
                currentHand.player3 = player3;




                if (currentHand.bankerTotal == currentHand.playerTotal)
                {
                    //tie hand
                    currentHand.result = HandResult.Tie;
                }
                else if (currentHand.bankerTotal > currentHand.playerTotal)
                {
                    //bank win
                    currentHand.result = HandResult.Banker;
                }
                else if (currentHand.bankerTotal < currentHand.playerTotal)
                {
                    //player win
                    currentHand.result = HandResult.Player;
                }
                else
                {
                    //error
                    currentHand.result = HandResult.Error;
                }

                currentHand.bankerTotal = currentHand.bankerTotal;
                currentHand.playerTotal = currentHand.playerTotal;
                return currentHand;
            }

            if (currentHand.bankerTotal == 6)
            {
                //6 draws

                if (player3.faceValue == 6 || player3.faceValue == 7)
                {
                    banker3 = mainShoe.Dequeue();
                    currentHand.bankerTotal += banker3.faceValue;
                }


                currentHand.banker1 = banker1;
                currentHand.banker2 = banker2;
                currentHand.banker3 = banker3;

                currentHand.player1 = player1;
                currentHand.player2 = player2;
                currentHand.player3 = player3;


                //6 check
                if (currentHand.bankerTotal == currentHand.playerTotal)
                {
                    //tie
                    currentHand.result = HandResult.Tie;
                }
                else if (currentHand.bankerTotal > currentHand.playerTotal)
                {
                    //banker win
                    currentHand.result = HandResult.Banker;
                }
                else if (currentHand.bankerTotal < currentHand.playerTotal)
                {
                    //player win
                    currentHand.result = HandResult.Player;
                }
                else
                {
                    currentHand.result = HandResult.Error;
                }

                currentHand.bankerTotal = currentHand.bankerTotal;
                currentHand.playerTotal = currentHand.playerTotal;

                return currentHand;

            }
            //5 draws

            if (currentHand.bankerTotal == 5)
            {

                if (player3.faceValue >= 4 && player3.faceValue <= 7 || player3.faceValue == 0)
                {
                    banker3 = mainShoe.Dequeue();
                    currentHand.bankerTotal += banker3.faceValue;
                }

                currentHand.banker1 = banker1;
                currentHand.banker2 = banker2;
                currentHand.banker3 = banker3;

                currentHand.player1 = player1;
                currentHand.player2 = player2;
                currentHand.player3 = player3;


                //5 check
                if (currentHand.bankerTotal == currentHand.playerTotal)
                {
                    //tie
                    currentHand.result = HandResult.Tie;
                }
                else if (currentHand.bankerTotal > currentHand.playerTotal)
                {
                    //banker win
                    currentHand.result = HandResult.Banker;
                }
                else if (currentHand.bankerTotal < currentHand.playerTotal)
                {
                    //player win
                    currentHand.result = HandResult.Player;
                }
                else
                {
                    currentHand.result = HandResult.Error;
                }

                currentHand.bankerTotal = currentHand.bankerTotal;
                currentHand.playerTotal = currentHand.playerTotal;

                return currentHand;
            }

            if (currentHand.bankerTotal == 4)
            {
                //4 draws

                if (player3.faceValue >= 2 && player3.faceValue <= 7 || player3.faceValue == 0)
                {
                    banker3 = mainShoe.Dequeue();
                    currentHand.bankerTotal += banker3.faceValue;
                }


                currentHand.banker1 = banker1;
                currentHand.banker2 = banker2;
                currentHand.banker3 = banker3;

                currentHand.player1 = player1;
                currentHand.player2 = player2;
                currentHand.player3 = player3;


                //4 check
                if (currentHand.bankerTotal == currentHand.playerTotal)
                {
                    //tie
                    currentHand.result = HandResult.Tie;
                }
                else if (currentHand.bankerTotal > currentHand.playerTotal)
                {
                    //banker win
                    currentHand.result = HandResult.Banker;
                }
                else if (currentHand.bankerTotal < currentHand.playerTotal)
                {
                    //player win
                    currentHand.result = HandResult.Player;
                }
                else
                {
                    currentHand.result = HandResult.Error;
                }

                currentHand.bankerTotal = currentHand.bankerTotal;
                currentHand.playerTotal = currentHand.playerTotal;

                return currentHand;
            }

            if (currentHand.bankerTotal == 3)
            {
                //3 draws
                if (player3.faceValue != 8)
                {
                    banker3 = mainShoe.Dequeue();
                    currentHand.bankerTotal += banker3.faceValue;
                }


                currentHand.banker1 = banker1;
                currentHand.banker2 = banker2;
                currentHand.banker3 = banker3;

                currentHand.player1 = player1;
                currentHand.player2 = player2;
                currentHand.player3 = player3;


                //3 check
                if (currentHand.bankerTotal == currentHand.playerTotal)
                {
                    //tie
                    currentHand.result = HandResult.Tie;
                }
                else if (currentHand.bankerTotal > currentHand.playerTotal)
                {
                    //banker win
                    currentHand.result = HandResult.Banker;
                }
                else if (currentHand.bankerTotal < currentHand.playerTotal)
                {
                    //player win
                    currentHand.result = HandResult.Player;
                }
                else
                {
                    currentHand.result = HandResult.Error;
                }


                currentHand.bankerTotal = currentHand.bankerTotal;
                currentHand.playerTotal = currentHand.playerTotal;

                return currentHand;
            }

            if (currentHand.bankerTotal <= 2)
            {
                //0, 1, 2 draws
                if (currentHand.bankerTotal <= 2)
                {
                    banker3 = mainShoe.Dequeue();
                    currentHand.bankerTotal += banker3.faceValue;
                }


                currentHand.banker1 = banker1;
                currentHand.banker2 = banker2;
                currentHand.banker3 = banker3;

                currentHand.player1 = player1;
                currentHand.player2 = player2;
                currentHand.player3 = player3;


                //0, 1, 2 check
                if (currentHand.bankerTotal == currentHand.playerTotal)
                {
                    //tie
                    currentHand.result = HandResult.Tie;
                }
                else if (currentHand.bankerTotal > currentHand.playerTotal)
                {
                    //banker win
                    currentHand.result = HandResult.Banker;
                }
                else if (currentHand.bankerTotal < currentHand.playerTotal)
                {
                    //player win
                    currentHand.result = HandResult.Player;
                }
                else
                {
                    currentHand.result = HandResult.Error;
                }

                currentHand.bankerTotal = currentHand.bankerTotal;
                currentHand.playerTotal = currentHand.playerTotal;

                return currentHand;


            }
            
            return currentHand;

        }
    }
}
