using System.Text.Json.Serialization;

namespace Agropet.Application;

public abstract record CommandQueryBase
{
    [JsonIgnore]
    public int UserId { get; set; }
    [JsonIgnore]
    public string? Email { get; set; }
}
