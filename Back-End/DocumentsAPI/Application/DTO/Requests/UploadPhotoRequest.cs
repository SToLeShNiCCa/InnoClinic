using Application.DTO.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.DTO.Requests
{
    public record UploadPhotoRequest(IFormFile File);
}
