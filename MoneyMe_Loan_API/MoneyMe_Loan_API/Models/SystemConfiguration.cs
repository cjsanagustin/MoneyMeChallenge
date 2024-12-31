using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMe_Loan_API.Models
{
    [Index(nameof(Code), nameof(Value), IsUnique = true)]
    public class SystemConfiguration
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Code { get; set; } = null!;
        [Column(TypeName = "varchar(100)")]
        public string Value { get; set; } = null!;
        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; } = null!;
    }
}
