namespace VeracidataApi.Application.Models.Responses
{
    public record CustomerResponse(
        long Id,
        string Name,
        string? NickName,
        string Phone,
        DateTime BirthDate,
        string Email,
        bool Active
    );
}
