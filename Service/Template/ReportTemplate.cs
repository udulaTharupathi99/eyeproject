using eyeproject.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace eyeproject.Service.Template;

public class ReportTemplate
{
    public ReportTemplate(PaientModel paientModel, ReportModel reportModel)
    {
        _paientModel = paientModel;
        _reportModel = reportModel;
    }

    private PaientModel _paientModel { get; }
    private ReportModel _reportModel { get; }
    
    public void Compose(IDocumentContainer container)
    {
        var titleStyle = TextStyle.Default.FontSize(13).Bold().FontColor(Colors.Blue.Medium);
        container
            .Page(page =>
            {
                page.DefaultTextStyle(TextStyle.Default.FontSize(11).FontFamily("Times New Roman")
                    .FontColor(Colors.Grey.Darken1));
                page.MarginBottom(20);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().AlignCenter().Column(x =>
                {
                    x.Item().Text(x =>
                    {
                        x.Span("Powered By ");
                        x.Hyperlink("OCULARTECH.AI", "abc").Style(titleStyle);
                    });
                    x.Item().AlignCenter().Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                        x.Span(" out of ");
                        x.TotalPages();
                    });
                });
            });
    }
    
    private void ComposeHeader(IContainer container)
    {
        var titleStyle = TextStyle.Default.FontSize(18).FontFamily("Times New Roman").FontColor(Colors.White);
        var subtitleStyle = TextStyle.Default.FontSize(9).FontFamily("Times New Roman").FontColor(Colors.Grey.Lighten2);
        var textStyle = TextStyle.Default.FontSize(9).FontColor(Colors.Grey.Lighten5);
        container.Background("#086db4").PaddingVertical(20).PaddingHorizontal(30).Row(row =>
        {
            row.RelativeItem().Column(column =>
            {
                column.Item().PaddingBottom(6).Text("OCULARTECH.AI").Style(titleStyle);

                column.Item().PaddingBottom(10).Text(text =>
                {
                    text.Span("Report ID: ").Style(subtitleStyle);
                    text.Span($"{_reportModel.ReportID}").Style(textStyle);
                });
                column.Item().PaddingBottom(10).Text(text =>
                {
                    text.Span("Date: ").Style(subtitleStyle);
                    text.Span(DateTime.Now.ToShortDateString()).Style(textStyle);
                });

                // column.Item().Text(text =>
                // {
                //     text.Span("Issue date: ").Style(subtitleStyle);
                //     text.Span(
                //             $"{InfrastructureHelperFunction.RemoveTimeFromDateTime(_invoiceModel.InvoiceDetails.InvoiceDate)}")
                //         .Style(textStyle);
                // });
                //
                // column.Item().Text(text =>
                // {
                //     text.Span("Due date: ").Style(subtitleStyle);
                //     text.Span(
                //             $"{InfrastructureHelperFunction.RemoveTimeFromDateTime(_invoiceModel.InvoiceDetails.DueDate)}")
                //         .Style(textStyle);
                // });
            });

            if (_reportModel.Logoimg != null)
                row.ConstantItem(100).AlignMiddle().Column(column =>
                {
                    column.Item().Height(90).Image(_reportModel.Logoimg, ImageScaling.FitArea);
                });
        });
    }
    
    private void ComposeContent(IContainer container)
    {
        var subtitleStyle = TextStyle.Default.FontFamily("Times New Roman");

        container.PaddingVertical(20).PaddingHorizontal(30).Column(column =>
        {
            column.Spacing(5);

            column.Item().Row(row =>
            {
                row.RelativeItem().Component(new PatientOne(_paientModel.FullName, _paientModel.Dob, _paientModel.Gender));
                row.ConstantItem(50);
                row.RelativeItem().Component(new PatientTwo(_paientModel.IdentityCardNo, _paientModel.MobileNo, _paientModel.Email, _paientModel.Address, _paientModel.District));
            });
            
            column.Item().Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Spacing(2);
                    column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5).Text("Img")
                        .Style(subtitleStyle);
                   
                    
                    column.Item().Height(90).Image(_reportModel.Img, ImageScaling.FitArea);
                });
            });

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Spacing(2);
                    column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5).Text("Res")
                        .Style(subtitleStyle);
                    column.Item().Text(_reportModel.Result);
                    column.Item().Text(_reportModel.Doctor_comment);
                    column.Item().Text(_reportModel.Scan_date);
                });
            });

            // column.Item().PaddingTop(20).Element(ComposeTable);
            // column.Item().PaddingTop(15).AlignRight().Element(ComposeSummaryTable);

            column.Item().Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Spacing(2);
                    column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingTop(5).PaddingBottom(5)
                        .Text("Notes").Style(subtitleStyle);
                    column.Item().Text($"{_reportModel.Doctor_comment}");
                });
            });
            
            column.Item().Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Spacing(2);
                    column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5).Text("QR")
                        .Style(subtitleStyle);
                    
                    
                    column.Item().Height(90).Image(_reportModel.QrImg, ImageScaling.FitArea);
                });
            });
        });
    }
}