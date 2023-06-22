using LoanData.Models.Group;
using LoanData.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanService.ServiceInterface
{
    public interface IGroupService
    {
        public List<LoanGroup> LoanGroupListAsync();
        public List<CollectionGroup> CollectionGroupListAsync();
        public Task<GroupCreatingViewModel> AddNewGroupAsync();
        public Task<GroupCreatingViewModel> AddNewLoanGroupAsync(GroupCreatingViewModel model);
        public Task<GroupCreatingViewModel> AddNewCollectionGroupAsync(GroupCreatingViewModel model);
        public Task<MemberWithGroupViewModel> AddMemberToGroupAsync(int groupId, int groupTypeId);
        public Task<GroupDetailsViewModel> GetGroupDetailsAsync(int id, int groupTypeId);
        public Task<MemberWithGroupViewModel> GroupMemberListAsync(int groupId, int groupTypeId);
        public Task<GroupDetailsViewModel> EditGroupDetailsAsync(int id, int groupTypeId);
        public Task<GroupDetailsViewModel> EditGroupDetailsAsync(GroupDetailsViewModel model);
        public MemberWithGroupViewModel CollectionGroupSelection();
        public MemberWithGroupViewModel LoanGroupSelection();
        bool Save();
    }
}
