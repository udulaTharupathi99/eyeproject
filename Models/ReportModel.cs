namespace eyeproject.Models;

public class ReportModel
{
    public string ReportID { get; set; }
    public string Qr { get; set; }
    public string Img_url { get; set; }
    public string Scan_date { get; set; }
    public string Result { get; set; }
    public string Doctor_comment { get; set; }
    
    
    //public string LogoUrl { get; set; }
    public Stream? Logoimg { get; set; }
    public Stream? Img { get; set; }
    public Stream? QrImg { get; set; }
}
