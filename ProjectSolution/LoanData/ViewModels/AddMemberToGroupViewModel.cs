using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.ViewModels
{
    public class AddMemberToGroupViewModel
    {
        public int GroupId { get; set; }
        public int GroupTypeId { get; set; }
        public long[] MemberNIDs { get; set; }
    }
}
