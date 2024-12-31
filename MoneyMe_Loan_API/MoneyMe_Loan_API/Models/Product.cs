using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMe_Loan_API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Description { get; set; } = null!;
        public bool IsInterestFree { get; set; }

        [Column(TypeName = "decimal(14,4)")]
        public decimal InterestRate { get; set; }

        public int FirstNoOfMonthsInterestFree { get; set; }
        public int MinNoOfMonths { get; set; }
        public int MaxNoOfMonths { get; set; }


    }
}
