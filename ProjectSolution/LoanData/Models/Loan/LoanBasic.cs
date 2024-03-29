﻿using System.ComponentModel.DataAnnotations;

namespace LoanData.Models.Loan
{
    public class LoanBasic : LoanCommon
    {
        [Key]
        public long LoanId { get; set; }
        public long SerialId { get; set; }
        public int LoanAmount { get; set; } = 0;
        public int InterestRate { get; set; } = 10;
        public int SubmissionTimeInMonth { get; set; } = 6;
        public int InstallmentDays { get; set; }
        public int InstallmentCount { get; set; }
        public int PerInstallmentAmount { get; set; }
        public int IncludedInterest { get; set; } = 0;
        public int ProcessingFee { get; set; } = 150;
        public int ExtraCharge { get; set; }
        public int TotalCharge { get; set; } = 120;
        public int RefundAmount { get; set; } = 0;
        public bool IsLoanPaymentComplete { get; set; } = false;
    }
}
