namespace AES.WebApi.Core.Identity
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiryHours { get; set; }
        public string Issuer { get; set; }
        public string ValidOn { get; set; }
    }
}
