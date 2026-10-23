using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KafeTerningkast.Models;

public class BoardGame : IValidatableObject
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Navn er påkrevd.")]
    public string Name { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Minste antall spillere må være minst 1.")]
    public int MinPlayers { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Største antall spillere må være minst 1.")]
    public int MaxPlayers { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Spilletiden må være over 0.")]
    public int PlayTimeMinutes { get; set; }

    public string Category { get; set; } = string.Empty;

    [Range(1, 6, ErrorMessage = "Terningkastet må være fra 1 til 6.")]
    public int Rating { get; set; }

    public string Description { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
    {
        if (MaxPlayers < MinPlayers)
        {
            yield return new ValidationResult(
                "Største antall spillere kan ikke være lavere enn minste antall.",
                new[] { nameof(MaxPlayers) });
        }
    }
}