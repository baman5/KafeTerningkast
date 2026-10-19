using KafeTerningkast.Models;

namespace KafeTerningkast.Data;

public static class GameData
{
    public static List<BoardGame> Games { get; } = new()
    {
        new()
        {
            Id = 1, Name = "Ludo",
            MinPlayers = 2,
            MaxPlayers = 4,
            PlayTimeMinutes = 30,
            Category = "Klassiker",
            Rating = 4,
            Description = "Få brikkene dine rundt brettet og først i mål."
        },
        new()
        {
            Id = 2,
            Name = "Den forsvunne diamanten",
            MinPlayers = 2,
            MaxPlayers = 6,
            PlayTimeMinutes = 45,
            Category = "Familie",
            Rating = 5,
            Description = "Let etter diamanten mens du reiser gjennom Afrika."
        },
        new()
        {
            Id = 3,
            Name = "Monopol",
            MinPlayers = 2,
            MaxPlayers = 6,
            PlayTimeMinutes = 90,
            Category = "Strategi",
            Rating = 3,
            Description = "Kjøp eiendommer og prøv å unngå konkurs."
        },
        new()
        {
            Id = 4,
            Name = "Villkatten 300",
            MinPlayers = 1,
            MaxPlayers = 6,
            PlayTimeMinutes = 20,
            Category = "Familiespill",
            Rating = 4,
            Description = "Finn bildene på brettet før de andre."
        },
        new()
        {
            Id = 5,
            Name = "Flåklypa: Fra Paris til Pyramidene",
            MinPlayers = 2,
            MaxPlayers = 5,
            PlayTimeMinutes = 45,
            Category = "Familie",
            Rating = 5,
            Description = "Bli med Reodor, Solan og Ludvig på eventyr."
        },
        new()
        {
            Id = 6,
            Name = "Ticket to Ride: Nordic Countries",
            MinPlayers = 2,
            MaxPlayers = 3,
            PlayTimeMinutes = 60,
            Category = "Strategi",
            Rating = 5,
            Description = "Bygg jernbaner mellom nordiske byer."
        },
        new()
        {
            Id = 7,
            Name = "Hvem er hvem?",
            MinPlayers = 2,
            MaxPlayers = 2,
            PlayTimeMinutes = 20,
            Category = "Familiespill",
            Rating = 3,
            Description = "Still spørsmål og finn ut hvilken figur motspilleren har."
        },
        new()
        {
            Id = 8,
            Name = "Stigespill",
            MinPlayers = 2,
            MaxPlayers = 4,
            PlayTimeMinutes = 30,
            Category = "Klassiker",
            Rating = 2,
            Description = "Klatre opp stigene og unngå å falle ned slangene."
        }
    };
}