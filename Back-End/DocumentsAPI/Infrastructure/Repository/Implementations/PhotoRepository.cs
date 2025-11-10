using Domain.Models;
using Domain.Models.PageModels;
using Infrastructure.DbSettings;
using Infrastructure.Repository.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repository.Implementations
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly IMongoCollection<Photo> _collection;
        public PhotoRepository(IOptions<DatabaseSettings> settings)
        {
            var mongoClient = new MongoClient(
                settings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                settings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<Photo>(
                settings.Value.CollectionName);
        }
        public Task AddAsync(Photo photo, CancellationToken token)
        {
            
        }

        public void Delete(string url)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedResult<Photo>> GetAll(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Photo?> GetByUrlAsync(string url, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string url, Photo newPhoto, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
