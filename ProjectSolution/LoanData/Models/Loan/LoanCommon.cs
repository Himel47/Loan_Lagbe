using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.Models.Loan
{
    public class LoanCommon
    {
        public long MemberId { get; set; }
        public int GroupId { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }
    }
}
