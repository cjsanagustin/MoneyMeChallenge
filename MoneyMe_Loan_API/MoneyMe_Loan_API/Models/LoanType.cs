using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMe_Loan_API.Models
{
    public class LoanType
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; } = null!;
    }
}
