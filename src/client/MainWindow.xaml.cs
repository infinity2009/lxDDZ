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

using lxDDZ.controller;
using lxDDZ.model;

namespace lxDDZ
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, IGameView
    {
        GameController GameController { get; set; }

        IActionDelegate ActionDelegate { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            this.GameController = new GameController(this);
            this.GameController.start();

            this.ActionDelegate = this.GameController;
        }

        private void HintBtn_Click(object sender, RoutedEventArgs e)
        {
            ActionDelegate.onHint();
        }

        private void PassBtn_Click(object sender, RoutedEventArgs e)
        {
            ActionDelegate.onPass();
        }

        private void ShowBtn_Click(object sender, RoutedEventArgs e)
        {
            ActionDelegate.onShowCard();
        }

        TextBlock _getCurrentPlayer(PlayerRound playerRound)
        {
            if (playerRound.Owner == playerRound.Current)
                return tbPlayer2;
            else if (playerRound.Owner.LeftPlayer == playerRound.Current)
                return tbPlayer1;
            else
                return tbPlayer3;
        }

        public void displayWin()
        {
            throw new NotImplementedException();
        }

        public void refreshPlayer(PlayerRound playerRound, int countDown)
        {
            tbPlayer1.Text = playerRound.Owner.LeftPlayer.Name;
            tbPlayer2.Text = playerRound.Owner.Name;
            tbPlayer3.Text = playerRound.Owner.RightPlayer.Name;

            this._getCurrentPlayer(playerRound).Text += string.Format(" {0}s", countDown);

            this._renderCard(playerRound);
        }

        delegate void mydelegate2(PlayerRound playerRound, int countDown);
        public void refreshPlayerSafe(PlayerRound playerRound, int countDown)
        {
            this.Dispatcher.BeginInvoke(new mydelegate2(refreshPlayer), playerRound, countDown);
        }

        void _renderCard(PlayerRound playerRound)
        {
            foreach (var item in playerRound.Current.HoldingCards)
            {
                CardUserControl displayCard = new CardUserControl();
                //cardGrid.Children.Add(displayCard);
            }
        }

        void _renderCard(int x, int y, Card card)
        {

        }
    }
}
