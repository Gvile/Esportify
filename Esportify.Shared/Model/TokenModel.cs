using System.Text.Json.Serialization;

namespace Esportify.Shared.Model;

public class TokenModel
{
    [JsonPropertyName("token")] public string Token { get; set; }
}