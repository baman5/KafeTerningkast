using Bunit;
using KafeTerningkast.Models;
using KafeTerningkast.Web.Components.Games;

namespace KafeTerningkast.Tests;

public class GameCardTests
{
    [Fact]
    public void AddButtonClick_InvokesCallbackWithGame()
    {
        using var context = new BunitContext();

        var game = new BoardGame
        {
            Id = 1,
            Name = "Catan",
            MinPlayers = 3,
            MaxPlayers = 4,
            PlayTimeMinutes = 90,
            Category = "Strategi",
            Rating = 4,
            Description = "Bygg bosetninger og konkurrer om ressurser."
        };

        BoardGame? receivedGame = null;

        var renderedCard = context.Render<GameCard>(parameters => parameters
            .Add(card => card.Game, game)
            .Add(
                card => card.OnAddToGameNight,
                selectedGame => receivedGame = selectedGame));

        renderedCard.Find("button").Click();

        Assert.Same(game, receivedGame);
    }
}