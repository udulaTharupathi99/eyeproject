using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace eyeproject.Service.Template;

public class InputImage : IComponent
{
    public InputImage(Stream img)
    {
        Img = img;
    }

    private Stream Img { get; }
    
    public void Compose(IContainer container)
    {
        var nameStyle = TextStyle.Default.FontFamily("Times New Roman").SemiBold();
        var subtitleStyle = TextStyle.Default.FontFamily("Times New Roman");

        container.PaddingBottom(10).Column(column =>
        {
            column.Spacing(2);

            column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5).PaddingTop(0).Text("Input Image")
                .Style(subtitleStyle);

            column.Item().Height(175).PaddingTop(10).Image(Img, ImageScaling.FitArea);
        });
    }
}