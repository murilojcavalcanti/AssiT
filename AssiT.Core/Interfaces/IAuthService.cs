namespace AssiT.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(string Email, int Id);
        string GenerateHash(string password);
    }
}
