namespace EasyIntern.Model;

public class InternshipAdvertisement
{
    public InternshipAdvertisement()
    {
        InternshipApplications = new List<InternshipApplication>();
    }
    public int Id { get; set; }
    public string CompanyLogo { get; set; }
    public Position Position { get; set; }
    public string Description { get; set; }
    public InternshipPeriod InternshipPeriod { get; set; }
    public List<InternshipApplication> InternshipApplications { get; set; }
    public Internship Internship { get; set; }
    public int InternshipId { get; set; }
    public int Quota { get; set; }
    public int RemainingSlots => Quota - InternshipApplications.Count(x => x.State == ApplicationState.Approved);

}