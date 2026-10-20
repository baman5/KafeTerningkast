using System;
using System.Collections.Generic;
using System.Linq;
using KafeTerningkast.Models;

namespace KafeTerningkast.Web.Services;

public class GameNightService
{
    public List<BoardGame> Games { get; } = new();

    public event Action? Changed;

    public bool AddGame(BoardGame game)
    {
        if (Games.Any(existingGame => existingGame.Id == game.Id))
        {
            return false;
        }

        Games.Add(game);
        Changed?.Invoke();

        return true;
    }

    public void RemoveGame(int gameId)
    {
        int removedCount = Games.RemoveAll(game => game.Id == gameId);

        if (removedCount > 0)
        {
            Changed?.Invoke();
        }
    }
}