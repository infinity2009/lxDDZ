﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lxDDZ.model;
using System.Timers;

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
        object LockObj { get; set; }

        public IGameView GameView { get; private set; }

        public int ThinkSeconds { get; set; }

        public PlayerRound PlayerRound { get; set; }

        public GameStatus Status { get; set; }

        int _countDown;
        int CountDown
        {
            get { return _countDown; }
            set
            {
                lock(this.LockObj)
                {
                    _countDown = value;
                }
            }
        }

        Timer CountDownTimer { get; set; }

        public GameController(IGameView gameView)
        {
            this.LockObj = new object();
            this.GameView = gameView;

            this.ThinkSeconds = 10;
            this.PlayerRound = new PlayerRound();

            this.CountDownTimer = new Timer(1000);
            this.CountDownTimer.Elapsed += CountDownTimer_Elapsed;

        }

        void CountDownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.CountDown -= 1;
            if (this.CountDown <= 0)
            {
                // 先手 必须出一张牌
                if (this.PlayerRound.Current.Upper)
                {
                    this.onShowCard();
                }
                else
                {
                    this.onPass();
                }
            }

            this.GameView.refreshPlayerSafe(this.PlayerRound, this.CountDown);
        }

        //! 开始
        public void start()
        {
            this._shuffle();

            this._deal();

            this._clearCountDown();

            this.GameView.refreshPlayer(this.PlayerRound, this.CountDown);
        }

        //! 结束
        public void over()
        {
            this.CountDownTimer.Enabled = false;

            // 通知view绘制游戏结束的场景
        }

        //! 洗牌
        void _shuffle() { }

        //! 发牌
        void _deal()
        {
            CardBunch full = CardBunch.GenerateFullCard();

            int i = 0;
            do
            {
                Card c = full.takeOneCard();
                this.PlayerRound[i].HoldingCards.Add(c);
                if (full.Count <= 3 || c == null)
                    break;
                i++;
                if (i >= this.PlayerRound.Count)
                    i = 0;
            } while (true);

            this.PlayerRound.Current = this.PlayerRound[0];
            this.PlayerRound.Current.Upper = true;
            this.PlayerRound.Current.HoldingCards.AddRange(full);

            for (int j = 0; j < this.PlayerRound.Count; j++)
            {
                this.PlayerRound[j].HoldingCards.Sort();
            }

            full.Clear();
        }

        //! 准备出的牌是否能出(牌型正确&&能压住上家)
        public bool canShowCard()
        {
            throw new NotImplementedException();
        }

        //! 出牌
        public void onShowCard()
        {
            this.PlayerRound.Current.showCard();
            if (PlayerRound.Current.Finished)
            {
                this.over();
            }

            this._moveNextPlayer();
        }

        //! 过
        public void onPass()
        {
            this.PlayerRound.Current.pass();

            this._moveNextPlayer();
        }

        //! 提示
        public void onHint()
        {
            throw new NotImplementedException();
        }

        //! 当地主
        public void onPreempt()
        {
            throw new NotImplementedException();
        }
        
        void _moveNextPlayer()
        {
            this.PlayerRound.Current = this.PlayerRound.Current.RightPlayer;
            this._clearCountDown();
            this.GameView.refreshPlayer(this.PlayerRound, this.CountDown);
        }

        void _clearCountDown()
        {
            this.CountDownTimer.Enabled = false;
            this.CountDown = this.ThinkSeconds;
            this.CountDownTimer.Enabled = true;
        }
        public void onClickCard(Card card)
        {
            if (this.PlayerRound.Owner.HangingCards.Contains(card))
                this.PlayerRound.Owner.HangingCards.Remove(card);
            else
                this.PlayerRound.Owner.HangingCards.Add(card);

            this.GameView.refreshPlayer(this.PlayerRound, this.CountDown);
        }
    }
}