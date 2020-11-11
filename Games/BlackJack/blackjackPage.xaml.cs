using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Card_Game.Games.BlackJack
{
    /// <summary>
    /// Interaction logic for blackjackPage.xaml
    /// </summary>
    public partial class blackjackPage : Page
    {
        bool handDealt = false;

        public blackjackPage()
        {
            InitializeComponent();
        }

        private void dealButton_Click(object sender, RoutedEventArgs e)
        {
            if (handDealt == false)
            {
                GameLogic.DealHand();
                playerCardOne.Source = new BitmapImage(new Uri(GameLogic.playerCards[0].imageSourceString, UriKind.Relative));
                playerCardTwo.Source = new BitmapImage(new Uri(GameLogic.playerCards[1].imageSourceString, UriKind.Relative));
                playerCountTextBlock.Text = GameLogic.playerCardValue.ToString();

                dealerCardOne.Source = new BitmapImage(new Uri(GameLogic.dealerCards[0].imageSourceString, UriKind.Relative));
                //change to hide the second card and value
                //dealerCardTwo.Source = new BitmapImage(new Uri(GameLogic.dealerCards[1].ImageSourceString, UriKind.Relative));
                //dealerCountTextBlock.Text = GameLogic.dealerCardValue.ToString();
                dealerCountTextBlock.Text = GameLogic.dealerCards[0].faceValue.ToString();



                dealerCardTwo.Source = new BitmapImage(new Uri(@"/images/card deck/back-red-1.png", UriKind.Relative));
                dealerCardThree.Visibility = Visibility.Hidden;
                dealerCardFour.Visibility = Visibility.Hidden;
                dealerCardFive.Visibility = Visibility.Hidden;

                playerCardThree.Visibility = Visibility.Hidden;
                playerCardFour.Visibility = Visibility.Hidden;
                playerCardFive.Visibility = Visibility.Hidden;

                winText.Text = "";

                handDealt = true;
                dealButton.IsEnabled = false;
                if (GameLogic.playerCardValue == 21 || GameLogic.dealerCardValue == 21)
                {
                    dealerCardTwo.Source = new BitmapImage(new Uri(GameLogic.dealerCards[1].imageSourceString, UriKind.Relative));
                    dealerCountTextBlock.Text = GameLogic.dealerCardValue.ToString();
                    playerCountTextBlock.Text = GameLogic.playerCardValue.ToString();
                    checkWin();
                }
                else
                {
                    hitButton.IsEnabled = true;
                    stayButton.IsEnabled = true;
                }
            }

        }

        private void hitButton_Click(object sender, RoutedEventArgs e)
        {
            if (handDealt == true)
            {

                GameLogic.HitCard();
                playerCardThree.Source = new BitmapImage(new Uri(GameLogic.playerCards[2].imageSourceString, UriKind.Relative));
                playerCardThree.Visibility = Visibility.Visible;
                if (GameLogic.playerCards[3] != null)
                {
                    playerCardFour.Source = new BitmapImage(new Uri(GameLogic.playerCards[3].imageSourceString, UriKind.Relative));
                    playerCardFour.Visibility = Visibility.Visible;
                }
                if (GameLogic.playerCards[4] != null)
                {
                    playerCardFive.Source = new BitmapImage(new Uri(GameLogic.playerCards[4].imageSourceString, UriKind.Relative));
                    playerCardFive.Visibility = Visibility.Visible;
                }

            }
            if (GameLogic.playerBust() == true)
            {
                //change
                hitButton.IsEnabled = false;
                stayButton.IsEnabled = false;
                dealer();
            }

            if (GameLogic.playerCardValue == 21)
            {
                //player has 21
                hitButton.IsEnabled = false;
                stayButton.IsEnabled = false;
                dealer();
            }
            playerCountTextBlock.Text = GameLogic.playerCardValue.ToString();
        }

        private void stayButton_Click(object sender, RoutedEventArgs e)
        {

            dealer();
            hitButton.IsEnabled = false;
            stayButton.IsEnabled = false;
        }

        private void resetBtn_Click(object sender, RoutedEventArgs e)
        {
            Stats.pWins = 0;
            Stats.pLosses = 0;
            pLoseTextBlock.Text = Stats.pLosses.ToString();
            pWinTextBlock.Text = Stats.pWins.ToString();
        }


        private void dealer()
        {
            dealerCardTwo.Source = new BitmapImage(new Uri(GameLogic.dealerCards[1].imageSourceString, UriKind.Relative));

            GameLogic.dealerDraw();
            if (GameLogic.dealerCards[2] != null)
            {
                dealerCardThree.Source = new BitmapImage(new Uri(GameLogic.dealerCards[2].imageSourceString, UriKind.Relative));
                dealerCardThree.Visibility = Visibility.Visible;

            }
            if (GameLogic.dealerCards[3] != null)
            {
                dealerCardFour.Source = new BitmapImage(new Uri(GameLogic.dealerCards[3].imageSourceString, UriKind.Relative));
                dealerCardFour.Visibility = Visibility.Visible;
            }
            if (GameLogic.dealerCards[4] != null)
            {
                dealerCardFive.Source = new BitmapImage(new Uri(GameLogic.dealerCards[4].imageSourceString, UriKind.Relative));
                dealerCardFive.Visibility = Visibility.Visible;
            }

            dealerCountTextBlock.Text = GameLogic.dealerCardValue.ToString();
            checkWin();
        }
        private void checkWin()
        {
            winText.Text = "Analyzing";
            if (GameLogic.dealerCardValue > 21)
            {
                if (GameLogic.playerCardValue > 21)
                {
                    winText.Text = "Player Bust";
                    Stats.pLosses++;
                }
                else if (GameLogic.playerCardValue <= 21)
                {
                    winText.Text = "Player Wins";
                    Stats.pWins++;
                }
                else
                {
                    winText.Text = "deal > 21 exception";
                }
            }

            if (GameLogic.dealerCardValue <= 21)
            {
                if (GameLogic.playerCardValue == GameLogic.dealerCardValue)
                {
                    winText.Text = "TIE PUSH";
                }
                else if (GameLogic.playerCardValue > 21)
                {
                    winText.Text = "PLAYER BUST";
                    Stats.pLosses++;
                }
                else if (GameLogic.playerCardValue < GameLogic.dealerCardValue)
                {
                    winText.Text = "Player Loses";
                    Stats.pLosses++;
                }
                else if (GameLogic.playerCardValue > GameLogic.dealerCardValue && GameLogic.playerCardValue <= 21)
                {
                    winText.Text = "Player Wins";
                    Stats.pWins++;
                }
                else
                {
                    winText.Text = "deal <= 21 exception";
                }

            }
            dealButton.IsEnabled = true;
            handDealt = false;
            pLoseTextBlock.Text = Stats.pLosses.ToString();
            pWinTextBlock.Text = Stats.pWins.ToString();
        }

    }
}
