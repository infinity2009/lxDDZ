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
using lxDDZ.model;

namespace lxDDZ
{
    /// <summary>
    /// Card.xaml 的交互逻辑
    /// </summary>
    public partial class CardUserControl : UserControl
    {
        public CardUserControl()
        {
            InitializeComponent();
        }

        string[] numberStr = new string[]{
            "3","4","5","6","7","8","9","10",
            "J","Q","K","A",
            "2",
            "J\nO\nK\nE\nR","J\nO\nK\nE\nR",
        };

        string[] suitStr = new string[] {
            "",
            "♠","♥","♦","♣",
        };

        public Card Card
        {
            get { return (Card)GetValue(CardProperty); }
            set
            {
                SetValue(CardProperty, value);

                Brush clr = Brushes.Black;
                switch (value.Suit)
                {
                    case Suit.None:
                        if (value.Number == Number.BigJoker)
                            clr = Brushes.Red;
                        break;
                    case Suit.Heart:
                    case Suit.Diamond:
                        clr = Brushes.Red;
                        break;
                    default:
                        break;
                }
                tbNumber.Foreground = tbSuit.Foreground = clr;

                tbNumber.Text = numberStr[(int)value.Number];
                tbSuit.Text = suitStr[(int)value.Suit];
            }
        }

        // Using a DependencyProperty as the backing store for Card.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardProperty =
            DependencyProperty.Register("Card", typeof(Card), typeof(CardUserControl));
    }
}
