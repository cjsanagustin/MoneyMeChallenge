using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMe_Loan_API.Models
{
    public class LoanApplication
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int LoanTypeId { get; set; }
        [Column(TypeName = "decimal(14,4)")]
        public decimal AmountRequired { get; set; }
        public int MonthlyTerm { get; set; }
        [Column(TypeName = "decimal(14,4)")]
        public decimal InterestRate { get; set; }
        [Column(TypeName = "decimal(14,4)")]
        public decimal MonthlyPayment { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
