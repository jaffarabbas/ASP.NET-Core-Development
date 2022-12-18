namespace GitCommiterApi.Repositories
{
    public interface IGitRepository
    {
        Task<List<string>> staggingfileList();
        Task<Dictionary<int, string>> gitRepositoryList();
    }
}
