using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace eyeproject.Service.Template;

public class PatientOne : IComponent
{
    public PatientOne(string name, string dob, string gender, string nic)
    {
        Name = name;
        Dob = dob;
        Gender = gender;
        NIC = nic;
    }

    private string Name { get; }
    private string Dob { get; }
    private string Gender { get; }
    private string NIC { get; }
    
    public void Compose(IContainer container)
    {
        var nameStyle = TextStyle.Default.FontFamily("Times New Roman").SemiBold();
        var subtitleStyle = TextStyle.Default.FontFamily("Times New Roman");

        container.PaddingBottom(10).PaddingTop(-20).Column(column =>
        {
            column.Spacing(2);

            // column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5).Text("Patient Details")
            //     .Style(subtitleStyle);

            // column.Item().Text(Name).SemiBold().Style(nameStyle);
            // column.Item().Text(Dob);
            // column.Item().Text(Gender);
            
            
            
            
            column.Item().Text(text =>
            {
                text.Span("Name : ").Style(subtitleStyle);
                text.Span(Name).Style(nameStyle);
            });
            column.Item().Text(text =>
            {
                text.Span("DOB : ").Style(subtitleStyle);
                text.Span(Dob).Style(nameStyle);
            });
            column.Item().Text(text =>
            {
                text.Span("Gender : ").Style(subtitleStyle);
                text.Span(Gender).Style(nameStyle);
            });
            column.Item().Text(text =>
            {
                text.Span("NIC : ").Style(subtitleStyle);
                text.Span(NIC).Style(nameStyle);
            });
        });
    }
}