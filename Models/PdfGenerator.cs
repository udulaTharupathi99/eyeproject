
using System.Drawing;
using QuestPDF;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

using QuestPDF.Helpers;

namespace eyeproject.Models;

public class PdfGenerator
{
    public Document GeneratePdf(string userName, string imageUrl)
    {
        // var document = new Document();
        //
        // // Add a page to the document
        // document.Pages.Add(page =>
        // {
        //     page.Margin(20);
        //
        //     // Add the user's name
        //     page.Text(userName, TextStyle.Default.Size(20));
        //
        //     // Add the user's image from a URL
        //     if (!string.IsNullOrEmpty(imageUrl))
        //     {
        //         var image = Image.FromUrl(imageUrl);
        //         page.Image(image, new Rectangle(100, 100, 200, 200));
        //     }
        // });
        //
        // return document;
        
        // code in your main method
        var d = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(20));

                page.Header()
                    .Text("Hello PDF!")
                    .SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(x =>
                    {
                        x.Spacing(20);

                        x.Item().Text(Placeholders.LoremIpsum());
                        x.Item().Image(Placeholders.Image(200, 100));
                    });

                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Page ");
                        x.CurrentPageNumber();
                    });
            });
        });

        return d;

    }
}