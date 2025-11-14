namespace Application.Eceptions.AzureExceptions
{
    public class AzureUploadPhotoException : Exception
    {
        public AzureUploadPhotoException(string message) : base(message) { }
    }
}
