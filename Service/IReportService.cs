using eyeproject.Models;
using QuestPDF.Fluent;

namespace eyeproject.Service;

public interface IReportService
{
    Task<Stream> CreateReport(CreateReportReq req);
}