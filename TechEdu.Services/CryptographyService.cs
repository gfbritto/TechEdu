using System.Security.Cryptography;
using System.Text;
using TechEdu.Services.Interfaces;

namespace TechEdu.Services
{
    public class CryptographyService : ICryptographyService
    {
        #region Private Fields
        private readonly Aes _aesAlg;
        #endregion

        #region Constructor
        public CryptographyService(string key, string iv)
        {
            _aesAlg = Aes.Create();
            _aesAlg.Key = Encoding.UTF8.GetBytes(key);
            _aesAlg.IV = Encoding.UTF8.GetBytes(iv);
        }
        #endregion

        #region Actions
        public async Task<string> EncryptStringAsync(string plainText)
        {
            byte[] encrypted;
            var encryptedText = string.Empty;

            var encryptTask = Task.Run(() =>
            {
                ICryptoTransform encryptor = _aesAlg.CreateEncryptor(_aesAlg.Key, _aesAlg.IV);

                try
                {
                    var msEncrypt = new MemoryStream();
                    var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);

                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.WriteAsync(plainText);
                    }
                    encrypted = msEncrypt.ToArray();

                    encryptedText = Convert.ToHexString(encrypted);
                    return encryptedText;
                }
                catch (Exception)
                {
                    throw new CryptographicException($"Erro ao encriptar:{plainText}");
                }
            });
            return await encryptTask;
        }

        public async Task<string> DecryptStringAsync(string encryptedText)
        {
            var decryptedText = string.Empty;

            var decryptTask = Task.Run(() =>
            {
                try
                {
                    var cipherText = Convert.FromHexString(encryptedText);

                    var decryptor = _aesAlg.CreateDecryptor(_aesAlg.Key, _aesAlg.IV);

                    var msDecrypt = new MemoryStream(cipherText);
                    var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                    var srDecrypt = new StreamReader(csDecrypt);
                    decryptedText = srDecrypt.ReadToEnd();
                    return decryptedText;
                }
                catch (Exception)
                {
                    throw new CryptographicException($"Erro ao decriptar: {encryptedText}");
                }
            });
            return await decryptTask;
        }
        #endregion
    }
}