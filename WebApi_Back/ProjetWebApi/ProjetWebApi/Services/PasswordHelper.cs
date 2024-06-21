namespace ProjetWebApi.Services
{
    public class PasswordHelper
    {
        public static bool VerifyUserPassword(string inputPassword, string storedHash, string storedSalt)
        {
            return PasswordHasher.VerifyPassword(inputPassword, storedSalt, storedHash);
        }
    }
}
