using LoanData;
using LoanData.Models.Member;
using LoanData.ViewModels;

namespace LoanService.ServiceInterface
{
    public interface IMemberService
    {
        public Task<List<NewMember>> GetMembersAsync();
        public Task<CreatingMemberViewModel> AddMemberAsync();
        public Task<CreatingMemberViewModel> AddMemberAsync(CreatingMemberViewModel model);
        public Task<MemberBase> GetMemberDetailsAsync(long nid);
        public Task<CreatingMemberViewModel> EditMemberDetails(long Nid);
        public Task<CreatingMemberViewModel> EditMemberDetails(CreatingMemberViewModel model);
    }
}
