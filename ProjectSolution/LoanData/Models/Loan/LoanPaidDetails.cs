using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.Models.Loan
{
    public class LoanPaidDetails
    {
        [Key]
        public int Id { get; set; }
        public string IsPaidDetails { get; set; }
    }
}
