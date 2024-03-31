namespace andy250.LogToDotnet
{
    public interface ILogToClient
    {
        Task<User?> GetUserById(string id, CancellationToken cancel = default);
        Task UpdateUser(User user, CancellationToken cancel = default);
    }
}