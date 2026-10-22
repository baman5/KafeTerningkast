using KafeTerningkast.Data;
using KafeTerningkast.Web.Components;
using KafeTerningkast.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<KafeTerningkast.Web.Services.GameNightService>();
builder.Services.AddHttpClient<KafeTerningkast.Web.Services.GameApiClient>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapGet("/api/games", () => GameData.Games);

app.MapGet("/api/games/{id:int}", (int id) =>
{
    var game = GameData.Games.FirstOrDefault(candidate => candidate.Id == id);

    if (game is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(game);
});

app.MapPost("/api/games", (BoardGame newGame) =>
{
    bool isInvalid =
        string.IsNullOrWhiteSpace(newGame.Name) ||
        newGame.MinPlayers < 1 ||
        newGame.MaxPlayers < newGame.MinPlayers ||
        newGame.PlayTimeMinutes <= 0 ||
        newGame.Rating < 1 ||
        newGame.Rating > 6;

    if (isInvalid)
    {
        return Results.BadRequest("Spilldataene er ugyldige.");
    }

    int nextId = GameData.Games.Count == 0
        ? 1
        : GameData.Games.Max(game => game.Id) + 1;

    newGame.Id = nextId;
    GameData.Games.Add(newGame);

    return Results.Created($"/api/games/{newGame.Id}", newGame);
});

app.MapPut("/api/games/{id:int}", (int id, BoardGame updatedGame) =>
{
    var existingGame = GameData.Games
        .FirstOrDefault(game => game.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound("Fant ikke spillet.");
    }

    bool isInvalid =
        string.IsNullOrWhiteSpace(updatedGame.Name) ||
        updatedGame.MinPlayers < 1 ||
        updatedGame.MaxPlayers < updatedGame.MinPlayers ||
        updatedGame.PlayTimeMinutes <= 0 ||
        updatedGame.Rating < 1 ||
        updatedGame.Rating > 6;

    if (isInvalid)
    {
        return Results.BadRequest("Spilldataene er ugyldige.");
    }

    existingGame.Name = updatedGame.Name;
    existingGame.MinPlayers = updatedGame.MinPlayers;
    existingGame.MaxPlayers = updatedGame.MaxPlayers;
    existingGame.PlayTimeMinutes = updatedGame.PlayTimeMinutes;
    existingGame.Category = updatedGame.Category;
    existingGame.Rating = updatedGame.Rating;
    existingGame.Description = updatedGame.Description;

    return Results.NoContent();
});

app.MapDelete("/api/games/{id:int}", (int id) =>
{
    var game = GameData.Games
        .FirstOrDefault(game => game.Id == id);

    if (game is null)
    {
        return Results.NotFound("Fant ikke spillet.");
    }

    GameData.Games.Remove(game);

    return Results.NoContent();
});

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();