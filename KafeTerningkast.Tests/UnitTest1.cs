using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KafeTerningkast.Models;

namespace KafeTerningkast.Tests;

public class BoardGameValidationTests
{
    [Fact]
    public void ValidGame_PassesValidation()
    {
        var results = ValidateGame(CreateValidGame());

        Assert.Empty(results);
    }

    [Fact]
    public void EmptyName_FailsValidation()
    {
        var game = CreateValidGame();
        game.Name = string.Empty;

        var results = ValidateGame(game);

        Assert.Contains(
            results,
            result => result.MemberNames.Contains(nameof(BoardGame.Name)));
    }

    [Fact]
    public void MaxPlayersLowerThanMinPlayers_FailsValidation()
    {
        var game = CreateValidGame();
        game.MinPlayers = 5;
        game.MaxPlayers = 4;

        var results = ValidateGame(game);

        Assert.Contains(
            results,
            result => result.MemberNames.Contains(nameof(BoardGame.MaxPlayers)));
    }
    [Fact]
    public void RatingOutsideOneToSix_FailsValidation()
    {
        var game = CreateValidGame();
        game.Rating = 0;

        var results = ValidateGame(game);

        Assert.Contains(
            results,
            result => result.MemberNames.Contains(nameof(BoardGame.Rating)));
    }

    private static List<ValidationResult> ValidateGame(BoardGame game)
    {
        var results = new List<ValidationResult>();
        var context = new ValidationContext(game);

        Validator.TryValidateObject(
            game,
            context,
            results,
            validateAllProperties: true);

        return results;
    }

    private static BoardGame CreateValidGame()
    {
        return new BoardGame
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
    }
}