using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lxDDZ.model;

namespace lxDDZ.controller
{
    public class GameController
    {
        public int ThinkSeconds { get; set; }

        public PlayerRound PlayerRound { get; set; }

        public GameController()
        {
            this.ThinkSeconds = 10;
            this.PlayerRound = new PlayerRound();
        }

        bool GameOver
        {
            get
            {
                for (int i = 0; i < this.PlayerRound.Count; i++)
                {
                    if (this.PlayerRound[i].Finished)
                        return true;
                }
                return false;
            }
        }

        public void start()
        {
            this._shuffle();

            this._deal();

            while (!this.GameOver)
            {
                ;
            }
        }

        public void over()
        {
            ;
        }

        void _shuffle() { }

        void _deal()
        {
            this.PlayerRound.Current = this.PlayerRound[0];
        }
    }
}