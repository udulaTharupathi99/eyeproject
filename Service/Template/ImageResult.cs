using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace eyeproject.Service.Template;

public class ImageResult : IComponent
{
    public ImageResult(string result, string date, string note)
    {
        Result = result;
        Date = date;
        Note = note;
    }

    private string Result { get; }
    private string Date { get; }
    private string Note { get; }
    
    public void Compose(IContainer container)
    {
        var nameStyle1 = TextStyle.Default.FontFamily("Times New Roman").Bold();
        var nameStyle2 = TextStyle.Default.FontFamily("Times New Roman").SemiBold();
        var subtitleStyle = TextStyle.Default.FontFamily("Times New Roman");

        container.PaddingBottom(10).Column(column =>
        {
            column.Spacing(2);

            column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5).Text("Results")
                .Style(subtitleStyle);
                
            column.Item().PaddingTop(10).Text(text =>
            {
                text.Span("Result : ").Style(subtitleStyle);
                text.Span(Result).Style(nameStyle1);
            });
            column.Item().Text(text =>
            {
                text.Span("Scan Date : ").Style(subtitleStyle);
                text.Span(Date).Style(nameStyle2);
            });
            column.Item().Text(text =>
            {
                text.Span("Comments : ").Style(subtitleStyle);
                text.Span(Note).Style(nameStyle2);
            });
            
            
            
        });
    }
    
}