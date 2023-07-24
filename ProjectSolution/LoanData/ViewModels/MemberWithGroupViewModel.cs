using LoanData.Models.Member;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoanData.ViewModels
{
    public class MemberWithGroupViewModel
    {
        public int GroupId { get; set; }
        public int GroupTypeId { get; set; }
        public SelectList? GroupTypes { get; set; }
        public string? GroupName { get; set; }
        public SelectList? AllGroups { get; set; }
        public List<MemberBase>? MembersList { get; set; }
        public List<long>? LoanPlannedMembers { get; set; }
    }
}
