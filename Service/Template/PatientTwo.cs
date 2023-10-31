using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace eyeproject.Service.Template;

public class PatientTwo :IComponent
{
    public PatientTwo(string nic, string mobileNo, string email, string address, string district)
    {
        NIC = nic;
        MobileNo = mobileNo;
        Email = email;
        Address = address;
        District = district;
    }

    private string NIC { get; }
    private string MobileNo { get; }
    private string Email { get; }
    private string Address { get; }
    private string District { get; }
    
    public void Compose(IContainer container)
    {
        var nameStyle = TextStyle.Default.FontFamily("Times New Roman").SemiBold();
        var subtitleStyle = TextStyle.Default.FontFamily("Times New Roman");

        container.PaddingBottom(10).PaddingTop(-20).Column(column =>
        {
            column.Spacing(2);

            // column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(20);
                
            // column.Item().Text(text =>
            // {
            //     text.Span("NIC : ").Style(subtitleStyle);
            //     text.Span(NIC).Style(nameStyle);
            // });
            column.Item().Text(text =>
            {
                text.Span("MobileNo : ").Style(subtitleStyle);
                text.Span(MobileNo).Style(nameStyle);
            });
            column.Item().Text(text =>
            {
                text.Span("Email : ").Style(subtitleStyle);
                text.Span(Email).Style(nameStyle);
            });
            column.Item().Text(text =>
            {
                text.Span("Address : ").Style(subtitleStyle);
                text.Span(Address).Style(nameStyle);
            });
            column.Item().Text(text =>
            {
                text.Span("District : ").Style(subtitleStyle);
                text.Span(District).Style(nameStyle);
            });
            
            // column.Item().Text(NIC);
            // column.Item().Text(MobileNo);
            // column.Item().Text(Email);
            // column.Item().Text(Address);
            // column.Item().Text(District);
        });
    }
}