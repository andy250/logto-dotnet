namespace andy250.LogToDotnet
{
    public class LogToConfig
    {
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string BaseUrl { get; set; }

        /// <summary>
        /// https://docs.logto.io/sdk/m2m/#access-logto-management-api
        /// </summary>
        public string ManagementApi { get; set; }
        public string? ManagementApiScope { get; set; }
    }
}
