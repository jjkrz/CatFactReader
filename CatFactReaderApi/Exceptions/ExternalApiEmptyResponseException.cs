namespace CatFactReaderApi.Exceptions
{
    public class ExternalApiEmptyResponseException : Exception
    {
        public ExternalApiEmptyResponseException(string message) : base(message) { }
    }
}
