using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lxDDZ.model
{
    public enum Suit
    {
        None = 0,

        Spade = 1,
        Heart,
        Diamond,
        Club,
    }

    public enum Number
    {
        Three = 0,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace,
        Two,
        SmallJoker,
        BigJoker,
    }

    public class Card
    {
        public Suit Suit { get; set; }

        public Number Number { get; set; }
    }

    public class CardBunch : List<Card>
    {
        public static CardBunch GenerateFullCard()
        {
            CardBunch result = new CardBunch();

            for (Suit i = Suit.Spade; i <= Suit.Club; i++)
            {
                for (Number j = Number.Three; j <= Number.Two; j++)
                {
                    result.Add(new Card() { Suit = i, Number = j });
                }
            }
            result.Add(new Card() { Suit = Suit.None, Number = Number.SmallJoker });
            result.Add(new Card() { Suit = Suit.None, Number = Number.BigJoker });

            return result;
        }

        public new void Sort()
        {
            base.Sort((c1, c2) =>
            {
                if (c1.Number > c2.Number)
                    return 1;
                else if (c1.Number < c2.Number)
                    return -1;
                else
                    return 0;
            });
        }
        Random r = new Random();

        public Card takeOneCard()
        {
            if (this.Count <= 0)
                return null;

            int index = 0;
            if (this.Count > 1)
                index = r.Next(1, 1000) % (this.Count - 1);

            return this.takeOneCard(index);
        }

        public Card takeOneCard(int index)
        {
            try
            {
                return this[index];
            }
            finally
            {
                this.RemoveAt(index);
            }
        }
    }
}