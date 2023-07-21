using LoanData.Models.Loan;

namespace LoanData.ViewModels
{
    public class PersonalInstallmentViewModel
    {
        public string MemberName { get; set; }
        public string GroupName { get; set; }
        public List<InstallmentPayment> PersonalInstallments { get; set; }
    }
}
