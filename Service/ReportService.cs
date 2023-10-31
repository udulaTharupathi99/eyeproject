using System.Reflection.Metadata;
using eyeproject.Models;


namespace eyeproject.Service;

public class ReportService : IReportService
{
    private IDocumentService _documentService;

    public ReportService(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    public async Task<Stream> CreateReport(CreateReportReq req)
    {
        var httpClient = new HttpClient();
        var logoUrl = "https://firebasestorage.googleapis.com/v0/b/reseach-db-1.appspot.com/o/logo%2Flogo.jpg?alt=media&token=b7c2fd3f-491d-4d94-bb54-70fe7e32f3c6&_gl=1*1bbacp2*_ga*MTMwOTY5NTU5Ny4xNjk4NTIwMjA2*_ga_CW55HF8NVT*MTY5ODc1Nzg3NS42LjEuMTY5ODc1Nzk5MS41Mi4wLjA";
        
        var imgStream = await httpClient.GetStreamAsync(new Uri(req.report.Img_url));
        var logoStream = await httpClient.GetStreamAsync(new Uri(logoUrl));
        var qrStream = await httpClient.GetStreamAsync(new Uri(req.report.Qr));
        
        req.report.Img = imgStream;
        req.report.Logoimg = logoStream;
        req.report.QrImg = qrStream;
        
        var res = await _documentService.GetPreviewPDF(req.paientData, req.report);
        
        
        return res;
    }
}