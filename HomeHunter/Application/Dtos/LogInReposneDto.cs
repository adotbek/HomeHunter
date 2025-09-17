namespace Application.Dtos;

public class LogInReposneDto
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public UserDto User { get; set; }
    public string TokenType { get; set; }
    public int Expires { get; set; }
}
