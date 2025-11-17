using Domain.Models;

namespace Infrastructure.PDFGenerator.Interface
{
    public interface IPDFGenerator
    {
        byte[] GenerateResultsPdf(Result result);
        //byte[] GenerateResultsPdfWithTemplate(IReadOnlyCollection<Result> results, string templatePath);
        //шаблон какой-то мб сделать
    }
}
