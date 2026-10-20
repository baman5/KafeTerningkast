using System.Collections.Generic;
using System.Linq;
using KafeTerningkast.Models;

namespace KafeTerningkast.Web.Services;

public class GameNightService
{
    public List<BoardGame> Games { get; } = new();

    public bool AddGame(BoardGame game)
    {
        if (Games.Any(existingGame => existingGame.Id == game.Id))
        {
            return false;
        }

        Games.Add(game);
        return true;
    }

    public void RemoveGame(int gameId)
    {
        Games.RemoveAll(game => game.Id == gameId);
    }
}