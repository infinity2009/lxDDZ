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
            this.DataContext = this;
        }

        public Color Color
        {
            get
            {
                return Colors.Red;
            }
        }

        public string DisplaySuit
        {
            get
            {
                return "♠";
            }
        }
    }
}
