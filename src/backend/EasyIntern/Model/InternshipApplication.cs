namespace EasyIntern.Model;

public class InternshipApplication
{
    public InternshipApplication()
    {
        State = ApplicationState.Pending;
    }

    public int Id { get; set; }
    public InternshipAdvertisement InternshipAdvertisement { get; set; }
    public int InternshipAdvertisementId { get; set; }
    public int InternId { get; set; }
    public Intern Intern { get; set; }
    public ApplicationState State { get; set; }
    public DateTime ApplicationDate { get; set; }


}