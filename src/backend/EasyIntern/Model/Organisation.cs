namespace EasyIntern.Model;

public class Organisation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int EmployeeSize { get; set; }
    public List<InternshipAdvertisement> InternshipAdvertisements { get; set; }
    public List<Internship> Internships { get; set; }
}

