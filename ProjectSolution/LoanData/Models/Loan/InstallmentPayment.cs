using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.Models.Loan
{
    public class InstallmentPayment : LoanCommon
    {
        [Key]
        public int Id { get; set; }
        public long LoanId { get; set; }
        public int InstallmentId { get; set; }
        public int InstalmentAmount { get; set; }
        public int PaidAmount { get; set; } = 0;
        public int RemainingAmount { get; set; } = 0;
        public string IsPaid { get; set; }
    }
}
