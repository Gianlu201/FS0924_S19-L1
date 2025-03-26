namespace FS0924_S19_L1.Settings
{
    public class Jwt
    {
        public required string Securitykey { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required int ExpiresInMinutes { get; set; }
    }
}
