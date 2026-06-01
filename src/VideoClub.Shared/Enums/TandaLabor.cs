using System.Text.Json.Serialization;

namespace VideoClub.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TandaLabor
{
    Matutina,
    Vespertina
}
