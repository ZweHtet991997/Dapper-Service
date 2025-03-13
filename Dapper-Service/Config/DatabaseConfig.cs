namespace Dapper_Service.Config
{
    public static class DatabaseConfig
    {
        public static string server = "SQL5111.site4now.net";
        public static string database = "db_a9a6b3_nkcommonservice";
        public static string userId = "db_a9a6b3_nkcommonservice_admin";
        public static string password = "NKsoftwarehouse*11";

        public static string GetConnectionString()
        {
            return $"Data Source={server};Initial Catalog={database};User Id={userId};Password={password};TrustServerCertificate=True";
        }
    }
}
