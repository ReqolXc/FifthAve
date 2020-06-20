using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FifthAve.Utils.Cryptography
{
    public class SecurityKey
    {
        public static SymmetricSecurityKey SymmetricSecurityKey 
            => new SymmetricSecurityKey(Encoding.ASCII.GetBytes("key_fjdsklfjs_dsjvjsdlkvlkd"));
    }
}
