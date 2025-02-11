namespace test.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string userId, string username);
    }
}
