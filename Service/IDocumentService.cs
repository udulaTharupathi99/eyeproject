using eyeproject.Models;

namespace eyeproject.Service;

public interface IDocumentService
{
    Task<Stream> GetPreviewPDF(PaientModel paientModel, ReportModel reportModel);
}