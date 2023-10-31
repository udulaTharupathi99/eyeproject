using eyeproject.Models;
using eyeproject.Service.Template;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace eyeproject.Service;

public class DocumentService : IDocumentService, IDocument
{
    public DocumentService(PaientModel paientModel, ReportModel reportModel)
    {
        _paientModel = paientModel;
        _reportModel = reportModel;
    }
    
    public DocumentService()
    {
    }

    private PaientModel _paientModel { get; }
    private ReportModel _reportModel { get; }

    public DocumentMetadata GetMetadata()
    {
        var documentMetaData = DocumentMetadata.Default;
        documentMetaData.DocumentLayoutExceptionThreshold = 1000000;
        return documentMetaData;
    }

    public void Compose(IDocumentContainer container)
    {
        var invoiceTemplate = new ReportTemplate(_paientModel, _reportModel);
        invoiceTemplate.Compose(container);
    }

    public async Task<Stream> GetPreviewPDF(PaientModel paientModel, ReportModel reportModel)
    {
        var file = new DocumentService(paientModel, reportModel).GeneratePdf();
        var stream = new MemoryStream(file);
        return stream;
    }
}