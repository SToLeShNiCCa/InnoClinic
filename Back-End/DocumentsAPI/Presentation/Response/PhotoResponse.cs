namespace Presentation.Response
{
    public record class PhotoResponse(Guid AzureFileId, string MongoPhotoId);
}
