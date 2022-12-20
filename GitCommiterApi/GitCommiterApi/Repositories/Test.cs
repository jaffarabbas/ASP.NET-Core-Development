namespace GitCommiterApi.Repositories
{
    public class Test : ITest
    {
        List<string> lst = new List<string>()
        {
            "1","2"
        };
        public Task<List<string>> data()
        {
            return Task.FromResult(lst);
        }
    }
}
