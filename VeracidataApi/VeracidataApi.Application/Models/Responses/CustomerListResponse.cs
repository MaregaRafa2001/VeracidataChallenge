namespace VeracidataApi.Application.Models.Responses
{
    public record CustomerListResponse(
        long Id,
        string Name,
        string Email,
        bool Active
    );
}
