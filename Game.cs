namespace CardGame;

public class Game

{
    private CardPool _cardPool;
    private int _player1Score;
    private int _player2Score;
    private Card? _lastPlayedCard;
    private Random _random;
    private int _activePlayer;
    private Func<Card, Card, bool> _rule;
    
    
    public Game(CardPool cardPool, Func<Card, Card, bool> matchRule)
    {
        _cardPool = cardPool;
        _lastPlayedCard = _cardPool.DealCard();
        _random = new Random();
        _activePlayer = ChooseRandomPlayer();
        _rule = matchRule;
    }

    private void PlayRound()
    {
        Card newCard = _cardPool.DealCard();
        CallRound(newCard);
        if (_rule(newCard, _lastPlayedCard))
        {
            int matchPlayer = ChooseRandomPlayer();
            CallMatch(matchPlayer);
            if (matchPlayer == 1) _player1Score++;
            else _player2Score++;
        }
        _lastPlayedCard = newCard;
        SwapPlayer();
    }

    private void CallOpening() => Console.WriteLine($"the {_lastPlayedCard} is dealt and player {_activePlayer} begins");

    private void CallRound(Card newCard) =>Console.WriteLine($"player {_activePlayer} deals the {newCard}");
    
    private void CallMatch(int matchPlayer) => Console.WriteLine($"player {matchPlayer} calls match!");
    
    private void CallWinner()
    {
        if (_player1Score > _player2Score) Console.WriteLine($"player 1 wins with {_player1Score} points to {_player2Score}!");
        else if (_player2Score > _player1Score) Console.WriteLine($"player 2 wins with {_player2Score} points to {_player1Score}!");
        else Console.WriteLine("it's a draw");
    }
    
    private void CallNeedCards() => Console.WriteLine("No cards in deck");


    public void Play()
    {
        if (_lastPlayedCard == null)
        {
            CallNeedCards();
        }
        else
        {
            CallOpening();
            for (int i = 0; i < _cardPool.Cards.Length - 1; i++) PlayRound();
            CallWinner();
        }
    }

    private int ChooseRandomPlayer()
    {
        return _random.Next(1,3);
    }

    private void SwapPlayer()
    {
        _activePlayer = _activePlayer == 1 ? 2 : 1;
    }
    
}