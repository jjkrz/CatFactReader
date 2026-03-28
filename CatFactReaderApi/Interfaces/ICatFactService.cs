using CatFactReaderApi.Models;

namespace CatFactReaderApi.Interfaces
{
    public interface ICatFactService
    {
        Task<CatFact> GetCatFactAsync();
    }
}
