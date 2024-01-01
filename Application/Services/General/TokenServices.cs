using Application.Interfaces.General.IServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.UseCases
{
    public class TokenServices : ITokenServices
    {
        public bool ValidateUserId(ClaimsIdentity identity, int userId)
        {
            try
            {
                var id = identity.Claims.FirstOrDefault(x => x.Type == "UserId").Value;

                if (id != userId.ToString())
                {
                    return false;
                }

                return true;
            }

            catch (ArgumentException)
            {
                return false;
            }
        }

        public int GetUserId(ClaimsIdentity identity)
        {
            var id = int.Parse(identity.Claims.FirstOrDefault(x => x.Type == "nameid").Value);
            return id;
        }

        public string GetClaim(string token, string claimName)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
                var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == claimName)?.Value;
                return claimValue;
            }
            catch (Exception)
            {
                //TODO: Logger.Error
                return null;
            }
        }
    }
}
