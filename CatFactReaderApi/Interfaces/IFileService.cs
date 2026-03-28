using CatFactReaderApi.Models;

namespace CatFactReaderApi.Interfaces
{
    public interface IFileService
    {
        Task AppendLineAsync(CatFact catFact);
    }
}
