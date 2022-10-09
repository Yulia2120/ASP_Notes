﻿namespace ASP_Notes.Models
{
    public class JWTSettings
    {
        public string SecretKey { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}