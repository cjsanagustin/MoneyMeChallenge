using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMe_Loan_API.Models
{
    [Index(nameof(Description), IsUnique = true)]
    public class BlacklistedDomain
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(255)")]
        public string Description { get; set; } = null!;
    }
}
