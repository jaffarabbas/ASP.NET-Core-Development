namespace GlobalErrorHandling.Exceptions
{
    public class UnAuthorizedAccessException : Exception
    {
        public UnAuthorizedAccessException(string msg) : base(msg) { }
    }
}
