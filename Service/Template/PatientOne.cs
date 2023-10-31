using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace eyeproject.Service.Template;

public class PatientOne : IComponent
{
    public PatientOne(string name, string dob, string gender)
    {
        Name = name;
        Dob = dob;
        Gender = gender;
    }

    private string Name { get; }
    private string Dob { get; }
    private string Gender { get; }
    
    public void Compose(IContainer container)
    {
        var nameStyle = TextStyle.Default.FontSize(15).FontFamily("Times New Roman").FontColor(Colors.Blue.Medium);
        var subtitleStyle = TextStyle.Default.FontFamily("Times New Roman");

        container.PaddingBottom(10).Column(column =>
        {
            column.Spacing(2);

            column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5).Text("Patient")
                .Style(subtitleStyle);

            column.Item().Text(Name).SemiBold().Style(nameStyle);
            column.Item().Text(Dob);
            column.Item().Text(Gender);
        });
    }
}