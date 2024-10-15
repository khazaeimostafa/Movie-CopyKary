using System.ComponentModel.DataAnnotations;

public class Student
{
    [Required]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FatherName { get; set; }
    public string City { get; set; }
}
