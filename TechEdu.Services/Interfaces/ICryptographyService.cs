namespace TechEdu.Services.Interfaces
{
    public interface ICryptographyService
    {
        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="plainText">text to encrypt</param>
        /// <returns>Encrypted string</returns>
        public Task<string> EncryptStringAsync(string plainText);

        /// <summary>
        /// Decrypt a encrypted string
        /// </summary>
        /// <param name="encryptedText">Encryted string to decrypt</param>
        /// <returns>Decrypted string</returns>
        public Task<string> DecryptStringAsync(string encryptedText);
    }
}
