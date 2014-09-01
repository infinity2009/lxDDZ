using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lxDDZ.model;

namespace lxDDZ.controller
{
    public enum GameStatus
    {
        Ready = 1,
        Playing = 2,
        Over = 3,
    }

    public class GameController : IActionDelegate
    {
        public int ThinkSeconds { get; set; }

        public PlayerRound PlayerRound { get; set; }

        public GameStatus Status { get; set; }

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
                switch (this.Status)
                {
                    case GameStatus.Ready:
                        break;
                    case GameStatus.Playing:
                        break;
                    case GameStatus.Over:
                        break;
                    default:
                        break;
                }
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

        public bool canShowCard()
        {
            throw new NotImplementedException();
        }

        public void showCard()
        {
            throw new NotImplementedException();
        }

        public void hint()
        {
            throw new NotImplementedException();
        }
        
        public void pass()
        {
            throw new NotImplementedException();
        }

        public void preemptive()
        {
            throw new NotImplementedException();
        }
    }
}