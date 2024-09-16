namespace CardGame;

public record CardPool
{
    public Card[] Cards { get; }
    int _positionInDeck;

    private CardPool(Deck deck, int count)
    {
        Cards = new Card[count * deck.Cards.Length];
        int index = 0;

        for (int i = 0; i < count; i++)
        {
            foreach (var card in deck.Cards)
            {
                Cards[index] = card;
                index++;
            }
        }
    }

    public CardPool(Deck deck, int count, bool shuffle) : this(deck, count)
    {
        Shuffle();
    }

    public void Shuffle()
    {
        Random.Shared.Shuffle(Cards);
    }

    public Card? DealCard()
    {
        return _positionInDeck >= Cards.Length ? null : Cards[_positionInDeck++];
    }
}

