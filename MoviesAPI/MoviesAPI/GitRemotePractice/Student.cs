using System.ComponentModel.DataAnnotations;

public class Student
{
    [Required]
    public int Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; set; }
    public string FatherName { get; private set; }
    public string City { get; private set; }
}
