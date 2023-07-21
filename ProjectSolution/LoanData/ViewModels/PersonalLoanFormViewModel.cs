using LoanData.Models.Loan;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanData.ViewModels
{
    public class PersonalLoanFormViewModel
    {
        public long SelectedMemberNID { get; set; }
        public string SelectedMemberName { get; set; }
        public int SelectedGroupId { get; set; }
        public string SelectedGroupName { get; set; }
        public LoanBasic LoanBasic { get; set; }
        public SelectList SubmissionPeriod { get; set; }
    }
}
