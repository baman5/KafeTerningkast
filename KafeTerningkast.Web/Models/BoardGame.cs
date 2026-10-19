namespace KafeTerningkast.Models;

public class BoardGame
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public int PlayTimeMinutes { get; set; }
    public string Category { get; set; } = string.Empty;
    public int Rating { get; set; }
    public string Description { get; set; } = string.Empty;
}