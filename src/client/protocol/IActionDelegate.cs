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

        void showCard();

        void hint();

        void pass();

        void preemptive();
    }
}
