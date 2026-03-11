using Xunit;
using SecureUserApp.Services;

namespace SecureUserApp.Tests
{
    public class AuthTests
    {
        [Fact]
        public void Register_ShouldHashPassword()
        {
            string password = "test123";

            string hashed = AuthService.HashPassword(password);

            Assert.NotEqual(password, hashed);
        }

        [Fact]
        public void Authenticate_ShouldReturnTrue_ForValidCredentials()
        {
            AuthService.Register("testuser", "test123");

            bool result = AuthService.Authenticate("testuser", "test123");

            Assert.True(result);
        }

        [Fact]
        public void Authenticate_ShouldReturnFalse_ForInvalidCredentials()
        {
            AuthService.Register("anotheruser", "pass123");

            bool result = AuthService.Authenticate("anotheruser", "wrongpass");

            Assert.False(result);
        }
        [Fact]
        public void Encrypt_ThenDecrypt_ShouldReturnOriginalText()
        {
            string originalText = "MySecretInformation";

            string encrypted = EncryptionService.Encrypt(originalText);
            string decrypted = EncryptionService.Decrypt(encrypted);

            Assert.Equal(originalText, decrypted);
        }
    }
}