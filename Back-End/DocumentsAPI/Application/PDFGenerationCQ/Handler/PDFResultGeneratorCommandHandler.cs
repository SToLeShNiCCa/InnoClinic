using Application.DTO;
using Domain.Models;
using Infrastructure.PDFGenerator.Interface;
using Mapster;
using MediatR;

namespace Application.PDFGenerationCQ.Handler
{
    public class PDFResultGeneratorCommandHandler(IPDFGenerator _pdfGenerator) : IRequestHandler<PDFGenerationCommand, PDFResultDTO>
    {

        public async Task<PDFResultDTO> Handle(PDFGenerationCommand request, CancellationToken cancellationToken)
        {
            var result = request.Result.Adapt<Result>();
            var pdfBytes = await Task.Run(() => _pdfGenerator.GenerateResultsPdf(result));

            return new PDFResultDTO
            {
                Content = pdfBytes,
                FileName = $"Results_Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf",
                ContentType = "application/pdf"
            };
        }
    }
}
