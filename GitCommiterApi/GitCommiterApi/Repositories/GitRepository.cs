using GitCommiterMethods;

namespace GitCommiterApi.Repositories
{
    public class GitRepository : IGitRepository
    {
        private readonly Commiter _gitCommiter;
        public GitRepository(Commiter commiter) { 
            this._gitCommiter = commiter;
        }

        public async Task<Dictionary<int, string>> gitRepositoryList() 
        {
            try
            {
                return _gitCommiter.GitPathList();
            }
            catch(Exception e)
            {
                return new Dictionary<int, string>()
                {
                    {
                         0 , ""+e.ToString()
                    }
                };
            }
        }

        public async Task<List<string>> staggingfileList(string path)
        {
            var data = this._gitCommiter.StageChanges(path);
            return data;
        }
    }
}
