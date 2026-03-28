using CatFactReaderApi.Interfaces;
using CatFactReaderApi.Models;

namespace CatFactReaderApi.Services
{
    internal class FileService : IFileService
    {
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        private readonly string fileName = "catfacts.txt";
        private readonly ILogger<FileService> _logger;

        public FileService(ILogger<FileService> logger)
        {
            _logger = logger;
        }

        public async Task AppendLineAsync(CatFact catFact)
        {
            _logger.LogInformation($"Appending cat fact to file: {catFact.Fact}, Length: {catFact.Length}");

            var line = catFact.ToString();

            await _semaphore.WaitAsync();
            try
            {
                await File.AppendAllTextAsync(fileName, line);
            }
            finally
            {
                _semaphore.Release();
            }

            _logger.LogInformation($"Successfully appended cat fact to file: {fileName}");
        }
    }
}
