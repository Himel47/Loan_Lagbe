using AutoMapper;
using LoanData.DBContext;
using LoanData.DTOs;
using LoanData.Models;
using LoanData.ViewModels;
using LoanService.ServiceInterface.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Service.Api
{
    public class ApiGroupService : IApiGroupService
    {
        private readonly MyContext context;
        private readonly IMapper mapper;

        public ApiGroupService(MyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<SelectiveMemberDto> GetAllMembers()
        {
            var members = context.Members.ToList().Select(x => mapper.Map<SelectiveMemberDto>(x));

            return members;
        }

        public async Task<JsonResult> AddMemberToGroup(AddMemberToGroupViewModel model)
        {
            int groupId = model.GroupId;
            int groupTypeId = model.GroupTypeId;
            var ExistingMemberIds = await context.MembersWithGroups
                .Where(x => x.GroupTypeId == groupTypeId && x.GroupId == groupId)
                .Select(x => x.MemberNID).ToListAsync();

            foreach (var memberNID in model.MemberNIDs)
            {
                if (!ExistingMemberIds.Contains(memberNID))
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
