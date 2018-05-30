namespace WebAPI.Models.OtherEF
{
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool IsRemember { get; set; }
    }
}
