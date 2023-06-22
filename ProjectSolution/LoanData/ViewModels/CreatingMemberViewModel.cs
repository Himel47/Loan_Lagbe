using LoanData.Models.Member;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.ViewModels
{
    public class CreatingMemberViewModel
    {
        public MemberBase Member { get; set; }
        public SelectList MaritalStatus { get; set; }
    }
}
