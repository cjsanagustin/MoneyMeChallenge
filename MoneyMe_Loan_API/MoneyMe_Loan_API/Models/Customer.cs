using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMe_Loan_API.Models
{
    [Index(nameof(FirstName), nameof(LastName), nameof(DateOfBirth), IsUnique = true)]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(32)")]
        public string URLGUID { get; set; } = null!;
        [Column(TypeName = "varchar(300)")]
        public string FirstName { get; set; } = null!;
        [Column(TypeName = "varchar(300)")]
        public string LastName { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string Title { get; set; } = null!;
        [Column(TypeName = "varchar(20)")]
        public string MobileNumber { get; set; } = null!;
        [Column(TypeName = "varchar(320)")]
        public string Email { get; set; } = null!;

        [Column(TypeName = "decimal(14,4)")]
        public decimal PrePopulateAmountRequired { get; set; }
        public int PrePopulateMonthlyTerm { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
