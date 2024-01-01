using System.Security.Claims;

namespace Application.Interfaces.General.IServices
{
    public interface ITokenServices
    {
        bool ValidateUserId(ClaimsIdentity identity, int userId);
        int GetUserId(ClaimsIdentity identity);
        string GetClaim(string token, string claimName);

    }
}
