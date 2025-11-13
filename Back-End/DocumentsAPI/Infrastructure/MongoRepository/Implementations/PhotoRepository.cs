using Domain.Models;
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
        public async Task CreateAsync(Photo photo, CancellationToken token)
        {
            await _collection.InsertOneAsync(photo);
        }

        public async Task DeleteAsync(string id, CancellationToken token)
        {
            await _collection.DeleteOneAsync(p => p.Id == id, token);
        }

        public async Task<Photo?> GetByIdAsync(string id, CancellationToken token)
        {
            return await _collection.Find(photo => photo.Id == id).FirstOrDefaultAsync(token);
        }

        public async Task UpdateAsync(string id, Photo newPhoto, CancellationToken token)
        {
            await _collection.ReplaceOneAsync(photo => photo.Id == id, newPhoto);
        }
    }
}
