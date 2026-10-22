using System.Net;
using System.Net.Http.Json;
using KafeTerningkast.Models;
using Microsoft.AspNetCore.Components;

namespace KafeTerningkast.Web.Services;

public class GameApiClient
{
    private readonly HttpClient _httpClient;

    public GameApiClient(HttpClient httpClient, NavigationManager navigation)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress ??= new Uri(navigation.BaseUri);
    }

    public async Task<List<BoardGame>> GetAllAsync()
    {
        var games = await _httpClient.GetFromJsonAsync<List<BoardGame>>(
            "api/games");

        return games ?? new List<BoardGame>();
    }

    public async Task<BoardGame?> GetByIdAsync(int id)
    {
        using var response = await _httpClient.GetAsync($"api/games/{id}");

        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<BoardGame>();
    }

    public async Task CreateAsync(BoardGame game)
    {
        using var response = await _httpClient.PostAsJsonAsync(
            "api/games",
            game);

        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(int id, BoardGame game)
    {
        using var response = await _httpClient.PutAsJsonAsync(
            $"api/games/{id}",
            game);

        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        using var response = await _httpClient.DeleteAsync(
            $"api/games/{id}");

        response.EnsureSuccessStatusCode();
    }
}