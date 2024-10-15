using System.ComponentModel.DataAnnotations;

public class Student
{
    [Required]
    public int Id { get; set; }
    public string FirstName { get; set; }
}