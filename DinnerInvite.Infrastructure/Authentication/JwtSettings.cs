namespace DinnerInvite.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string sectionName = "JwtSettings";
        public string secret { get; init; } = null;
        public int expMinutes { get; init; }
        public string issuer { get; init; } = null;
        public string auddiance { get; init; } = null;
    }
}