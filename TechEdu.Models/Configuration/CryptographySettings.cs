namespace TechEdu.Models.Configuration
{
    public class CryptographySettings
    {
        /// <summary>
        /// Key for cryptography
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// InicializationVector for cryptography
        /// </summary>
        public string InicializationVector { get; set; }
    }
}