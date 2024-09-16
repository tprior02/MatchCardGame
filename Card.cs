namespace CardGame;

public record Card(Suit suit, CardValue value)
{
    public readonly Colour colour = suit == Suit.Club | suit == Suit.Spade ? Colour.Black : Colour.Red;
    
    public override string ToString() => $"{value} of {suit}s";
}

