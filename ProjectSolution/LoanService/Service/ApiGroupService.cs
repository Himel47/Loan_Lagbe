using LoanData.DBContext;
using LoanData.Models;
using LoanData.ViewModels;
using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Service
{
    public class ApiGroupService : IApiGroupService
    {
        private readonly MyContext context;

        public ApiGroupService(MyContext context)
        {
            this.context = context;
        }

        public async Task<JsonResult> AddMemberToGroup(AddMemberToGroupViewModel model)
        {
            int groupId = model.GroupId;
            int groupTypeId = model.GroupTypeId;
            var ExistingMemberIds = await context.MembersWithGroups
                .Where(x=>x.GroupTypeId == groupTypeId && x.GroupId == groupId)
                .Select(x=>x.MemberNID).ToListAsync();

            foreach(var memberNID in model.MemberNIDs)
            {
                if(!ExistingMemberIds.Contains(memberNID))
                {
                    MemberWithGroup memberWithGroup = new()
                    {
                        GroupId = groupId,
                        GroupTypeId = groupTypeId,
                        MemberNID = memberNID
                    };
                    await context.MembersWithGroups.AddAsync(memberWithGroup);
                }
            }
            await context.SaveChangesAsync();
            return new JsonResult("Ok");
        }
    }
}
