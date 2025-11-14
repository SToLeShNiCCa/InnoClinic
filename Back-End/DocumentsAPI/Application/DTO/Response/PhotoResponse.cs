namespace Application.DTO.Response
{
    public record class PhotoResponse(Guid AzureFileId, string MongoPhotoId);
}
