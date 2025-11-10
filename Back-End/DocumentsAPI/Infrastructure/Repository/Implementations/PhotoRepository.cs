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
        public async Task AddAsync(Photo photo, CancellationToken token)
        {
            await _collection.InsertOneAsync(photo);
        }

        public async Task DeleteAsync(string url, CancellationToken token)
        {
            await _collection.DeleteOneAsync(p => p.Url == url, token);
        }

        public async Task<PaginatedResult<Photo>> GetAllAsync(PageInfo pageInfo, CancellationToken token)
        {
            var totalRecords = await _collection.CountDocumentsAsync(_ => true);

            var offices = await _collection
                .Find(_ => true)
                .Skip((pageInfo.Page - 1) * pageInfo.ItemsPerPage)
                .Limit(pageInfo.ItemsPerPage)
                .ToListAsync(token);

            return new PaginatedResult<Photo>
                (
                offices,
                pageInfo.Page,
                pageInfo.ItemsPerPage,
                totalRecords
                );
        }

        public async Task<Photo?> GetByUrlAsync(string url, CancellationToken token)
        {
            return await _collection.Find(photo => photo.Url == url).FirstOrDefaultAsync(token);
        }

        public async Task UpdateAsync(string url, Photo newPhoto, CancellationToken token)
        {
            await _collection.ReplaceOneAsync(photo => photo.Url == url, newPhoto);
        }
    }
}
