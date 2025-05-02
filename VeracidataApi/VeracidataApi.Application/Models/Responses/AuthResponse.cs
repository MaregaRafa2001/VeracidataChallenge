namespace VeracidataApi.Application.Models.Responses
{
    public record AuthResponse(
        long Id,
        string Email,
        string Token
    );
}
