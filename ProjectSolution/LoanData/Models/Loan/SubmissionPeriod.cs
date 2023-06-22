using System.ComponentModel.DataAnnotations;

namespace LoanData.Models.Loan
{
    public class SubmissionPeriod
    {
        [Key]
        public int SubmissionPeriodId { get; set; }
        public string SubmissionName { get; set; }
        public int SubmissionPeriodDays { get; set; }
    }
}