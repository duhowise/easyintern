namespace EasyIntern.Model;

public class Internship
{
    public int Id { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
  
    public Organisation Organisation { get; set; }
    public int OrganisationId { get; set; }
    public Position Position { get; set; }
    public int PositionId { get; set; }
    public Intern Intern { get; set; }
    public int InternId { get; set; }
}