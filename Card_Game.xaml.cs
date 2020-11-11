using Card_Game.Games.Baccarrat;
using Card_Game.Games.BlackJack;
using Card_Game.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Navigation;

namespace Card_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        blackjackPage blackjack = new blackjackPage();
        baccPage baccarrat = new baccPage();

        public MainWindow()
        {
            InitializeComponent();
            gameFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            playerOne.StaticPropertyChanged += PlayerOne_StaticPropertyChanged;
        }

        private void PlayerOne_StaticPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            userText.Text = $"Welcome {playerOne.firstName}, {playerOne.lastName}!";
            bankText.Text = $"Current Bankroll is $ {playerOne.bankRoll}";
            shoeProgress.Value = playerOne.shoeProgress;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void blackjackNavBtn_Click(object sender, RoutedEventArgs e)
        {

            gameFrame.Navigate(blackjack);
            
        }

        private void baccNavBtn_Click(object sender, RoutedEventArgs e)
        {
            gameFrame.Navigate(baccarrat);
            
        }
    }
}
