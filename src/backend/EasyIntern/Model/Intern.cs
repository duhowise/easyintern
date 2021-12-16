namespace EasyIntern.Model;

public class Intern
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public List<InternshipApplication> InternshipApplications { get; set; }
}