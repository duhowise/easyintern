namespace EasyIntern.Model;

public class Intern
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public string Address { get; set; }
    public List<InternshipApplication> InternshipApplications { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
}