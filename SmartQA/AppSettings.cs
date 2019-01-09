namespace SmartQA
{    
    public class AppSettings
    {
        public string FileStoragePath { get; set; }
        public string JwtKey { get; set; }
        public string JwtIssuer { get; set; }
        public int JwtExpireDays { get; set; }                
    }
}