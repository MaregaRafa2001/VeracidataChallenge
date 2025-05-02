namespace VeracidataApi.Application.Models.Requests
{
    public class RegisterRequest
    {
        public required string Name { get; set; }
        public string? NickName { get; set; }
        public required string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
