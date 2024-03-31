using System.Text.Json.Serialization;

namespace andy250.LogToDotnet.DTO
{
    public sealed class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("primaryEmail")]
        public string PrimaryEmail { get; set; }
    }
}
