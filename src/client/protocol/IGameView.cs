using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lxDDZ.model;

namespace lxDDZ
{
    public interface IGameView
    {
        void refreshPlayer(PlayerRound playerRound, int countDown);

        void refreshPlayerSafe(PlayerRound playerRound, int countDown);

        void refreshHoleCards(CardBunch holdCards);

        void displayWin();
    }
}
