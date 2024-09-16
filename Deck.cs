namespace CardGame;

using System;

public record Deck
{
    public Card[] Cards { get; }

    public Deck()

    {
        Cards = new Card[52];
        var i = 0;

        foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                Cards[i] = new Card(suit, value);
                i++;
            }
        }
    }
}