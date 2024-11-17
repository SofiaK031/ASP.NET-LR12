using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LR12.Models
{
    [Table("company")]
    public class CompanyModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [Column("year_of_establishment")]
        public int? YearOfEstablishment { get; set; }

        [MaxLength(100)]
        public string Industry { get; set; }

        public CompanyModel(string name, string address, int? yearOfEstablishment, string industry)
        {
            Name = name;
            Address = address;
            YearOfEstablishment = yearOfEstablishment;
            Industry = industry;
        }
    }
}