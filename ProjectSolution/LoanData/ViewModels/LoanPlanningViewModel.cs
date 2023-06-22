using LoanData.Models.Group;
using LoanData.Models.Loan;
using LoanData.Models.Member;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.ViewModels
{
    public class LoanPlanningViewModel
    {
        public List<LoanBasic> loanBasic { get; set; }
        public LoanGroup loanGroup { get; set; }
        public SelectList SubmissionPeriod { get; set; }
        public List<MemberBase> MemberList { get; set; }
        public List<InstallmentPayment>? AllInstallment { get; set; }
    }
}
