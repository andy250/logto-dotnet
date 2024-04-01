namespace andy250.LogToDotnet
{
    public class LogToConfig
    {
        public string BaseUrl { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }

        /// <summary>
        /// https://docs.logto.io/sdk/m2m/#access-logto-management-api
        /// </summary>
        public string ApiId { get; set; }
        public string? ApiScope { get; set; }
    }
}
