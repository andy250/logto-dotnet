namespace andy250.LogToDotnet
{
    internal static class Endpoints
    {
        public const string Applications = "applications";
        public const string Users = "users";
        public static string User(string id) => $"users/{id}";
    }
}
