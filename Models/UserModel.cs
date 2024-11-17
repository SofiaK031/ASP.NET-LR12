using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("first_name")]
    public string FirstName { get; set; }
    [Column("second_name")]
    public string SecondName { get; set; }
    public int Age { get; set; }
    public UserModel(string firstName, string secondName, int age)
    {
        FirstName = firstName;
        SecondName = secondName;
        Age = age;
    }
}