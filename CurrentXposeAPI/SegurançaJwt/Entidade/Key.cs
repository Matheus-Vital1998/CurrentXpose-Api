namespace CurrentXposeAPI.Segurança.Entidade
{
    public class Key
    {
        private readonly IConfiguration _configuration;

        public Key(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static string Secret = _configuration["AppSetting:SecretJwt"];
    }
}
