using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lxDDZ.model
{
    public enum PlayerStatus
    {
        Thinking = 1,
        Watting = 2,
    }

    public enum Character
    {
        Landlord = 1,
        Farmer = 2,
    }

    public class Player
    {
        public PlayerStatus Status { get; set; }

        public string Name { get; set; }

        public CardBunch HoldingCards { get; set; }

        public CardBunch ShowingCards { get; set; }

        public bool Finished { get; set; }

        public Character Character { get; set; }

        public Player LeftPlayer { get; set; }

        public Player RightPlayer { get; set; }

        public Player()
        {
            this.Character = Character.Farmer;
        }

        public void preemptive()
        {
            this.Character = Character.Landlord;
        }

        public void showCard() { }

        public void pass() { }

        public void win() { }

        public void lose() { }
    }

    public class PlayerRound
    {

        Player _current = null;
        Player[] _players;

        public int Count { get; set; }

        public Player Current
        {
            get { return _current; }
            set
            {
                _current = value;
                _current.Status = PlayerStatus.Thinking;
                _current.LeftPlayer.Status = PlayerStatus.Watting;
            }
        }

        //IEnumerable<Player> Excludes(Player player)
        //{
        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        if (_players[i] != player)
        //            yield return _players[i];
        //    }
        //}

        public PlayerRound()
        {
            this.Count = 3;
            _players = new Player[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                _players[i] = new Player();
            }

            _players[0].Name = "Computer1";
            _players[1].Name = "Computer2";
            _players[2].Name = "Player";

            for (int i = 0; i < this.Count; i++)
            {
                int left = (i - 1) < 0 ? this.Count : i - 1;
                int right = (i + 1) >= this.Count ? 0 : i + 1;
                _players[i].LeftPlayer = _players[left];
                _players[i].RightPlayer = _players[right];
            }
        }

        public Player this[int index]
        {
            get
            {
                return this._players[index];
            }
        }
    }
}
