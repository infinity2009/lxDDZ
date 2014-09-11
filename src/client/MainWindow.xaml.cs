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
            int count = playerRound.Owner.HoldingCards.Count;
            cardSeqGrid.Children.Clear();
            for (int i = count - 1; i >= 0; i--)
            {
                var item = playerRound.Owner.HoldingCards[i];

                CardUserControl displayCard = new CardUserControl();
                displayCard.Margin = new Thickness((count - i - 1) * 30, 0, 0, 0);
                displayCard.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                displayCard.MouseDown += displayCard_MouseDown;
                displayCard.Card = item;

                if (playerRound.Owner.HangingCards.Contains(item))
                    displayCard.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                else
                    displayCard.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;

                cardSeqGrid.Children.Add(displayCard);
            }
        }

        void displayCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CardUserControl cardControl = e.Source as CardUserControl;
            if (cardControl != null)
            {
                this.ActionDelegate.onClickCard(cardControl.Card);
            }
        }

        public void refreshHoleCards(CardBunch holdCards)
        {
            ;
        }
    }
}
