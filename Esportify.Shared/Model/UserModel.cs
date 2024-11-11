using System.Text.Json.Serialization;

namespace Esportify.Shared.Model;

public class UserModel
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("email")] public string Email { get; set; }
    [JsonPropertyName("password")] public string Password { get; set; }
    [JsonPropertyName("pseudo")] public string Pseudo { get; set; }
    [JsonPropertyName("roleId")] public int RoleId { get; set; }
}