using LoanData.DTOs;
using LoanData.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.ServiceInterface.Api
{
    public interface IApiGroupService
    {
        public IEnumerable<SelectiveMemberDto> GetAllMembers();

        public Task<JsonResult> AddMemberToGroup(AddMemberToGroupViewModel model);

        public Task<int> AddNewGroup(GroupCreatingViewModel model);

        public Task<int> AddNewLoanGroupAsync(GroupCreatingViewModel model);

        public Task<int> AddNewCollectionGroupAsync(GroupCreatingViewModel model);
    }
}
