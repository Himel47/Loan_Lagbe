using System.ComponentModel.DataAnnotations;

namespace LoanData.Models.Loan
{
    public class GroupLoan : LoanCommon
    {
        [Key]
        public int Id { get; set; }
        public long GroupLoanId { get; set; } = 0;
        public bool IsLoanRunning { get; set; }
    }
}
