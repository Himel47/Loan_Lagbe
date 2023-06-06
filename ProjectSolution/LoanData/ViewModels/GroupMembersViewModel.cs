using LoanData.Models.Group;
using LoanData.Models.Member;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.ViewModels
{
    public class GroupMembersViewModel
    {
        public int GroupId { get; set; }
        public LoanGroup LoanGroup { get; set; }
        public IEnumerable<MemberBase> GroupMembers { get; set; }
    }
}
