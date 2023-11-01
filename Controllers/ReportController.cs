using eyeproject.Models;
using eyeproject.Service;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;

namespace eyeproject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : Controller
{
    private IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    
   
    [HttpPost("report")]
    public async Task<IActionResult> CreateReport([FromBody] CreateReportReq request)
    {
        
        var result = await _reportService.CreateReport(request);
        //return result;
        return File(result, "application/pdf", request.report.ReportID);
    }
}