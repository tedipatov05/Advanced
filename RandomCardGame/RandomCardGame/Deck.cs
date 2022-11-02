using System;
using System.Collections.Generic;
using System.Text;

namespace RandomCardGame
{
    public class Deck
    {
        public Deck(int cardCount)
        {
            for (int i = 1; i <= cardCount; i++)
            {
                cards.Add(new Card($"Card №{i}"));
            }
        }
        public List<Card> cards = new List<Card>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var card in cards)
            {
                sb.AppendLine(card.ToString());
            }

            return sb.ToString();
        }

    }
}
