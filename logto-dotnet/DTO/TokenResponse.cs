﻿using System.Text.Json.Serialization;

namespace andy250.LogToDotnet.DTO
{
    internal class TokenResponse
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; init; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; }
        
        [JsonPropertyName("expires_in")]
        public int ExpiresIn{ get; init; }
    }
}