namespace VeracidataApi.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? NickName { get; set; }
        public required string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool Active { get; set; }
    }
}
