using AutoMapper;
using LoanData.DBContext;
using LoanData.DTOs;
using LoanData.Models;
using LoanData.Models.Group;
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

        public async Task<int> AddNewGroup(GroupCreatingViewModel model)
        {
            if (model.GrouptypeId == 1)
            {
                var response = await context.LoanGroups
                    .Where(x => x.LoanGroupName == model.NewGroupName)
                    .SingleOrDefaultAsync();

                if (response != null)
                {
                    return 1;
                }

                await AddNewLoanGroupAsync(model);
                return 3;

            }
            else if (model.GrouptypeId == 2)
            {
                var response = await context.CollectionGroups
                    .Where(x => x.CollectionGroupName == model.NewGroupName)
                    .SingleOrDefaultAsync();

                if (response != null)
                {
                    return 1;
                }

                await AddNewCollectionGroupAsync(model);
                return 3;
            }
            return 0;
        }

        public async Task<int> AddNewLoanGroupAsync(GroupCreatingViewModel model)
        {
            var group = new LoanGroup
            {
                LoanGroupName = model.NewGroupName,
                Location = model.GroupLocation,
                CreatedAt = model.CreatedAt
            };
            var loan = await context.LoanGroups.AddAsync(group);
            context.SaveChanges();

            var response = await context.LoanGroups
                .FirstOrDefaultAsync(x =>
                    x.LoanGroupName == model.NewGroupName
                );

            model.Id = response.LoanGroupId;
            return 1;
        }

        public async Task<int> AddNewCollectionGroupAsync(GroupCreatingViewModel model)
        {
            var group = new CollectionGroup
            {
                CollectionGroupName = model.NewGroupName,
                Location = model.GroupLocation,
                CreatedAt = model.CreatedAt
            };
            var loan = await context.CollectionGroups.AddAsync(group);
            context.SaveChanges();

            var response = await context.CollectionGroups
                .FirstOrDefaultAsync(x =>
                    x.CollectionGroupName == model.NewGroupName
                );

            model.Id = response.CollectionGroupId;
            return 1;
        }

    }
}
