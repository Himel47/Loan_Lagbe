using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.Models.Loan
{
    public class Installment : LoanCommon
    {
        [Key]
        public int Id { get; set; }
        public int InstallmentCount { get; set; }
        public int InstallmentDays { get; set; }
        public bool Paid { get; set; }=false;
    }
}
