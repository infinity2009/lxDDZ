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

        //! 手里握着的牌
        public CardBunch HoldingCards { get; set; }

        //! 刚刚打出的牌
        public CardBunch ShowingCards { get; set; }

        //! 准备出的牌
        public CardBunch HangingCards { get; set; }

        //! 牌是否出完
        public bool Finished { get; set; }

        //! 角色 (地主/农民)
        public Character Character { get; set; }

        //! 上家
        public Player LeftPlayer { get; set; }

        //! 下家
        public Player RightPlayer { get; set; }

        //! 是否先手
        public bool Upper { get; set; }

        public Player()
        {
            this.Character = Character.Farmer;

            this.HangingCards = new CardBunch();
            this.HoldingCards = new CardBunch();
            this.ShowingCards = new CardBunch();
        }

        //! 当地主
        public void preempt()
        {
            this.Character = Character.Landlord;
        }

        //! 出牌
        public void showCard()
        {
            this.LeftPlayer.Upper = false;
            this.Upper = true;
        }

        //! 过牌/不当地主
        public void pass() { }

        //! 胜利
        public void win() { }

        //! 失败
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

        public Player Owner
        {
            get;
            private set;
        }

        public PlayerRound()
        {
            this.Count = 3;
            _players = new Player[this.Count];
            for (int i = 0; i < this.Count; i++)
            {
                _players[i] = new Player();
            }

            for (int i = 0; i < this.Count; i++)
            {
                int left = (i - 1) < 0 ? this.Count - 1 : i - 1;
                int right = (i + 1) >= this.Count ? 0 : i + 1;
                _players[i].LeftPlayer = _players[left];
                _players[i].RightPlayer = _players[right];
            }

            _players[0].Name = "Computer1";
            _players[1].Name = "Computer2";
            _players[2].Name = "Player";
            this.Owner = _players[2];
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
