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
        var nameStyle = TextStyle.Default.FontSize(15).FontFamily("Times New Roman").FontColor(Colors.Blue.Medium);
        var subtitleStyle = TextStyle.Default.FontFamily("Times New Roman");

        container.PaddingBottom(10).Column(column =>
        {
            column.Spacing(2);

            column.Item().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingBottom(5).Text("Patient2")
                .Style(subtitleStyle);

            column.Item().Text(NIC);
            column.Item().Text(MobileNo);
            column.Item().Text(Email);
            column.Item().Text(Address);
            column.Item().Text(District);
        });
    }
}