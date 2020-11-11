using Card_Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Card_Game.Games.Baccarrat
{
    /// <summary>
    /// Interaction logic for baccPage.xaml
    /// </summary>
    public partial class baccPage : Page
    {
        private Queue<baccHand> currentShoe = baccDealer.completedHands;
        private int bankerCounter;
        private int playerCounter;
        private int tieCounter;
        private int handCount;
        private decimal currentBet;
        private decimal chipStack = 1000;

        public baccPage()
        {
            InitializeComponent();
            resetScreen();
        }


        private void newShoeButton_Click(object sender, RoutedEventArgs e)
        {
            currentShoe = new Queue<baccHand>();
            currentShoe = baccDealer.buildRound();
            resetScreen();
        }

        private void dealNextHandButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentShoe.Count > 0)
            {
                dealHand();
            }
            else
            {
                resultText.Text = "Shoe Finished";
            }

        }

        private void dealHand()
        {

            baccHand currentHand = currentShoe.Dequeue();
            playerCard1.Text = currentHand.player1.faceValue.ToString();
            playerCard2.Text = currentHand.player2.faceValue.ToString();
            if (currentHand.player3.faceValue == 0)
            {
                playerCard3.Text = "No Draw";
            }
            else if (currentHand.player3.faceValue == -1)
            {
                playerCard3.Text = "Error";
            }
            else
            {
                playerCard3.Text = currentHand.player3.faceValue.ToString();
            }

            bankerCard1.Text = currentHand.banker1.faceValue.ToString();
            bankerCard2.Text = currentHand.banker2.faceValue.ToString();
            if (currentHand.banker3.faceValue == 0)
            {
                bankerCard3.Text = "No Draw";
            }
            else if (currentHand.banker3.faceValue == -1)
            {
                bankerCard3.Text = "Error";
            }
            else
            {
                bankerCard3.Text = currentHand.banker3.faceValue.ToString();
            }

            bankerResult.Text = currentHand.bankerTotal.ToString();
            playerResult.Text = currentHand.playerTotal.ToString();

            switch (currentHand.result)
            {
                case HandResult.Banker:
                    resultText.Text = "Banker Wins";
                    bankerCounter++;
                    break;
                case HandResult.Player:
                    resultText.Text = "Player Wins";
                    playerCounter++;
                    break;
                case HandResult.Tie:
                    resultText.Text = "Tie Hand";
                    tieCounter++;
                    break;
                case HandResult.Error:
                    resultText.Text = "!!! Error Hand !!!";
                    break;
                default:
                    resultText.Text = "default View error";
                    break;
            }

            handBet(currentHand.result);

            bankerOneImage.Source = new BitmapImage(new Uri(currentHand.banker1.imageSourceString, UriKind.Relative));
            bankerTwoImage.Source = new BitmapImage(new Uri(currentHand.banker2.imageSourceString, UriKind.Relative));

            playerOneImage.Source = new BitmapImage(new Uri(currentHand.player1.imageSourceString, UriKind.Relative));
            playerTwoImage.Source = new BitmapImage(new Uri(currentHand.player2.imageSourceString, UriKind.Relative));


            if (currentHand.banker3.faceValue == 0)
            {
                bankerThreeImage.Source = new BitmapImage(new Uri($@"/images/card deck/back-blue-2.png", UriKind.Relative));
            }
            else
            {
                bankerThreeImage.Source = new BitmapImage(new Uri(currentHand.banker3.imageSourceString, UriKind.Relative));

            }

            if (currentHand.player3.faceValue == 0)
            {
                playerThreeImage.Source = new BitmapImage(new Uri($@"/images/card deck/back-blue-2.png", UriKind.Relative));
            }
            else
            {
                playerThreeImage.Source = new BitmapImage(new Uri(currentHand.player3.imageSourceString, UriKind.Relative));

            }

            handCount++;
            handCountTextBlock.Text = handCount.ToString();
            bankerCountTextBlock.Text = bankerCounter.ToString();
            playerCountTextBlock.Text = playerCounter.ToString();
            tieCountTextBlock.Text = tieCounter.ToString();


        }

        private void dealAllHandButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentShoe.Count == 0)
            {
                currentShoe = new Queue<baccHand>();
                currentShoe = baccDealer.buildRound();
                resetScreen();
            }
            else
            {

                while (currentShoe.Count > 0)
                {
                    dealHand();
                }
                resultText.Text = "Shoe Finished";
            }

        }

        private void resetScreen()
        {
            resultText.Text = "New Shoe Ready";
            bankerCard1.Text = "1st Bank";
            bankerCard2.Text = "2nd Bank";
            bankerCard3.Text = "3rd Bank";
            playerCard1.Text = "1st Player";
            playerCard2.Text = "2nd Player";
            playerCard3.Text = "3rd Player";
            bankerResult.Text = "0";
            playerResult.Text = "0";


            bankerCounter = 0;
            playerCounter = 0;
            tieCounter = 0;
            handCount = 0;
            handCountTextBlock.Text = handCount.ToString();
            bankerCountTextBlock.Text = bankerCounter.ToString();
            playerCountTextBlock.Text = playerCounter.ToString();
            tieCountTextBlock.Text = tieCounter.ToString();
            bankerOneImage.Source = new BitmapImage(new Uri($@"/images/card deck/back-blue-2.png", UriKind.Relative));
            bankerTwoImage.Source = new BitmapImage(new Uri($@"/images/card deck/back-blue-2.png", UriKind.Relative));
            bankerThreeImage.Source = new BitmapImage(new Uri($@"/images/card deck/back-blue-2.png", UriKind.Relative));
            playerOneImage.Source = new BitmapImage(new Uri($@"/images/card deck/back-blue-2.png", UriKind.Relative));
            playerTwoImage.Source = new BitmapImage(new Uri($@"/images/card deck/back-blue-2.png", UriKind.Relative));
            playerThreeImage.Source = new BitmapImage(new Uri($@"/images/card deck/back-blue-2.png", UriKind.Relative));

            chipStackUpdate(0);
        }


        private void _25dollarButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                currentBet -= 25;
                if (currentBet < 0) currentBet = 0;

            }
            else
            {
                currentBet += 25;
            }

            currentBetTextBlock.Text = $"$ {currentBet}";
        }

        private void _5dollarButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                currentBet -= 5;
                if (currentBet < 0) currentBet = 0;
            }
            else
            {
                currentBet += 5;
            }

            currentBetTextBlock.Text = $"$ {currentBet}";
        }

        private void _1dollarButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                currentBet -= 1;
                if (currentBet < 0) currentBet = 0;
            }
            else
            {
                currentBet += 1;
            }

            currentBetTextBlock.Text = $"$ {currentBet}";
        }

        private void removeAllBetsButton_Click(object sender, RoutedEventArgs e)
        {
            currentBet = 0;
            currentBetTextBlock.Text = $"$ {currentBet}";
        }

        private void chipStackUpdate(decimal change)
        {
            chipStack += change;
            chipStackTextBlock.Text = $"$ {chipStack}";
        }

        private void handBet(HandResult result)
        {
            greenWinLabel.Visibility = Visibility.Hidden;
            redLoseLabel.Visibility = Visibility.Hidden;
            tieLabel.Visibility = Visibility.Hidden;

            if (currentBet == 0)
            {
                currentBet = 1;
                currentBetTextBlock.Text = $"$ {currentBet}";
            }

            switch (result)
            {
                case HandResult.Banker:
                    if (bankerRadioButton.IsChecked == true)
                    {
                        greenWinLabel.Visibility = Visibility.Visible;
                        amountWonTextBlock.Text = $"$ {currentBet * (decimal)0.95}";
                        chipStackUpdate(currentBet * (decimal)0.95);
                    }
                    else
                    {
                        redLoseLabel.Visibility = Visibility.Visible;
                        amountWonTextBlock.Text = $"$ {-currentBet}";
                        chipStackUpdate(-currentBet);
                    }
                    break;
                case HandResult.Player:
                    if (playerRadioButton.IsChecked == true)
                    {
                        greenWinLabel.Visibility = Visibility.Visible;
                        amountWonTextBlock.Text = $"$ {currentBet}";
                        chipStackUpdate(currentBet);
                    }
                    else
                    {
                        redLoseLabel.Visibility = Visibility.Visible;
                        amountWonTextBlock.Text = $"$ {-currentBet}";
                        chipStackUpdate(-currentBet);
                    }
                    break;
                case HandResult.Tie:
                    tieLabel.Visibility = Visibility.Visible;
                    amountWonTextBlock.Text = "$ 0";
                    break;
                case HandResult.Error:
                    break;
                default:
                    break;
            }
        }

        private void chipStackTextBlock_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            chipStackTextBlock.IsReadOnly = false;
            chipStackTextBlock.Text = "";
            chipStackButton.Visibility = Visibility.Visible;
        }

        private void chipStackButton_Click(object sender, RoutedEventArgs e)
        {
            decimal stack = 0;
            bool convert = decimal.TryParse(chipStackTextBlock.Text, out stack);
            if (convert && stack > 0)
            {
                chipStack = stack;
                chipStackTextBlock.IsReadOnly = true;
                chipStackButton.Visibility = Visibility.Hidden;
                chipStackTextBlock.Text = $"$ {chipStack}";

                chipStackTextBlock.ToolTip = "Double Click to Add";
            }
            else
            {
                chipStackTextBlock.Text = "";
                chipStackTextBlock.ToolTip = "Please Enter a valid number";
            }

        }
    }
}
