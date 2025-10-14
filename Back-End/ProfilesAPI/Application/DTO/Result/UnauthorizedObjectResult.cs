using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.DTO.Result
{
    public class UnauthorizedObjectResult : ObjectResult
    {
        public UnauthorizedObjectResult(object error)
            : base(error)
        {
            base.StatusCode = 403;
        }
    }
}