using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lxDDZ.model;

namespace lxDDZ
{
    public interface IActionDelegate
    {
        bool canShowCard();

        void onShowCard();

        void onHint();

        void onPass();

        void onPreempt();

        void onClickCard(Card card);
    }
}
