using LoanData.DTOs;
using LoanData.Models.Loan;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanData.ViewModels
{
    public class GroupLoanFormViewModel
    {
        public int SelectedGroupId { get; set; }
        public string SelectedGroupName { get; set; }
        public List<SelectiveMemberDto> GroupMemebrs { get; set; }
        public IList<LoanBasic> Loans { get; set; }
        public SelectList SubmissionPeriod { get; set; }
        public int SubmissionTimeInDays { get; set; }
    }
}
