using LoanData;
using LoanData.Models.Member;
using LoanData.ViewModels;

namespace LoanService.ServiceInterface
{
    public interface IMemberService
    {
        public List<NewMember> GetMembersAsync();
        public Task<MemberBase> AddMemberAsync(MemberBase member);
//        public Task<AddMemberToGroupViewModel> AddMemberToGroupAsync();
        public Task<MemberBase> GetMemberDetailsAsync(long nid);
        public Task<MemberBase> EditMemberDetails(long Nid);
        public Task<MemberBase> EditMemberDetails(MemberBase response);
    }
}
