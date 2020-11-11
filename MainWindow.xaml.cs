using Card_Game.Games.Baccarrat;
using Card_Game.Games.BlackJack;
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
