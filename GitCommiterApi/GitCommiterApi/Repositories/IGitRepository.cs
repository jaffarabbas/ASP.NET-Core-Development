namespace GitCommiterApi.Repositories
{
    public interface IGitRepository
    {
        Task<List<string>> staggingfileList(string path);
        Task<Dictionary<int, string>> gitRepositoryList();
    }
}
