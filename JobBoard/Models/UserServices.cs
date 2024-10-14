using Microsoft.AspNetCore.Identity;

namespace JobBoard.Models
{
    public class UserServices
    {
        private readonly PasswordHasher<User> _passwordHasher;

        public UserServices()
        {
            _passwordHasher = new PasswordHasher<User>();
        }

        //Méthode pour hasher un mot de passe
        public string HashPassword(User user, string password)
        {
            return _passwordHasher.HashPassword(user, password);
        }

        //Méthode vérifiant le mot de passe 
        public bool VerifyPassword(User user, string password, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(user, password, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
