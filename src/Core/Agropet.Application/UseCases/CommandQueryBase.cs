using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Agropet.Application.UseCases;

public abstract record CommandQueryBase
{
    [JsonIgnore]
    public int? UserId { get; set; }
    [JsonIgnore]
    public string? Email { get; set; }
}
