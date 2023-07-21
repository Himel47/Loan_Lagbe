using System.ComponentModel.DataAnnotations;

namespace LoanData.Models.Loan
{
    public class Installment : LoanCommon
    {
        [Key]
        public int Id { get; set; }
        public int InstallmentCount { get; set; }
        public int InstallmentDays { get; set; }
        public bool Paid { get; set; } = false;
    }
}
