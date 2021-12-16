namespace EasyIntern.Model;

public class OrganisationUsers
{
    public int Id { get; set; }
    public Organisation Organisation { get; set; }
    public int OrganisationId { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}