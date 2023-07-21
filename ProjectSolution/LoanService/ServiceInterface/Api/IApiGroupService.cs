using LoanData.DTOs;
using LoanData.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoanService.ServiceInterface.Api
{
    public interface IApiGroupService
    {
        public IEnumerable<SelectiveMemberDto> GetAllMembers();
        public Task<JsonResult> AddMemberToGroup(AddMemberToGroupViewModel model);
    }
}
