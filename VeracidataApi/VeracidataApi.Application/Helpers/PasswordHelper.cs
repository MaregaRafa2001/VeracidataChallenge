using BCrypt.Net;

namespace VeracidataApi.Application.Helpers
{
    public static class PasswordHelper
    {
        public static string Hash(string plainTextPassword)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(plainTextPassword, HashType.SHA512);

        public static bool Verify(string plainText, string hashedPassword)
            => BCrypt.Net.BCrypt.EnhancedVerify(plainText, hashedPassword, HashType.SHA512);
    }
}
