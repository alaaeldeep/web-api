namespace Day3.Data
{
    public record LoginDto(string Name, string Password);
    public record RegisterDto(string UserName,
    string Email,
    string Password,
    string FaviouritColor);

    public record userData(string? UserName, string? FaviouritColor, string? Email);
}
