using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lxDDZ
{
    public interface IActionDelegate
    {
        bool canShowCard();

        void onShowCard();

        void onHint();

        void onPass();

        void onPreempt();
    }
}
