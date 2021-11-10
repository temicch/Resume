namespace Resume.Domain;

public class Person
{
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public DateTime? BirthDay { get; set; }
    public string? Position { get; set; }
    public string? Location { get; set; }
    public string? Email { get; set; }
    public List<PortfolioItem>? Portfolio { get; set; }
    public List<Contact>? Contacts { get; set; }
    public List<Education>? EducationList { get; set; }
    public List<List<HardSkill>>? HardSkillsGroups { get; set; }
    public List<Language>? Languages { get; set; }
    public List<string>? About { get; set; }
}
