using CardGame;

internal class Program
{
    public static void Main(string[] args)
    {
        var pool = new CardPool(new Deck(),2, true);
        var game = new Game(pool, (card1, card2) => card1.suit == card2.suit);

        game.Play();

    }
}

