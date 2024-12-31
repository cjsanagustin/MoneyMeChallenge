using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMe_Loan_API.Models
{
    [Index(nameof(Description), IsUnique = true)]
    public class BlacklistedMobileNumber
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string Description { get; set; } = null!;
    }
}
