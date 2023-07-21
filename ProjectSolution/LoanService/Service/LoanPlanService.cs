using AutoMapper;
using LoanData.DBContext;
using LoanData.DTOs;
using LoanData.Models.Loan;
using LoanData.Models.Member;
using LoanData.ViewModels;
using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Service
{
    public class LoanPlanService : ILoanPlanService
    {
        private readonly MyContext context;
        private readonly IMapper mapper;

        public LoanPlanService(MyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }


        public async Task<List<Installment>> GetMainPage()
        {
            var AllInstallments = await context.InstallmentDetails.ToListAsync();
            return AllInstallments;
        }

        public async Task<List<MemberBase>> MemberSelectForLoanPlan()
        {
            var MemberList = await context.Members.ToListAsync();
            return MemberList;
        }

        public async Task<LoanPlanGroupSelectionViewModel> MemberGroupSelectForLoanPlan(long memberNid, int groupId)
        {
            var singleMember = await context.Members
                .Where(x => x.NID == memberNid)
                .Select(x => mapper.Map<SelectiveMemberDto>(x))
                .SingleOrDefaultAsync();

            var groupIds = await context.InstallmentDetails
                .Where(x => x.MemberId == memberNid)
                .Select(x => x.GroupId)
                .ToListAsync();

            var vm = new LoanPlanGroupSelectionViewModel
            {
                MemberContainingGroups = new(),
                LoanTakenGroupIds = new(),
                Member = singleMember
            };
            vm.LoanTakenGroupIds = groupIds;

            if (groupId == 0)
            {
                var SelectedGroups = await context.MembersWithGroups
                    .Where(x => x.MemberNID == memberNid && x.GroupTypeId == 1)
                    .Select(x => x.GroupId).ToListAsync();
                foreach (var SinglegroupId in SelectedGroups)
                {
                    var SingleGroup = mapper.Map<LoanGroupDto>(await context.LoanGroups
                            .Where(x => x.LoanGroupId == SinglegroupId)
                            .SingleOrDefaultAsync());
                    vm.MemberContainingGroups.Add(SingleGroup);
                }
            }
            else
            {
                var SingleGroup = mapper.Map<LoanGroupDto>(await context.LoanGroups
                        .Where(x => x.LoanGroupId == groupId)
                        .SingleOrDefaultAsync());
                vm.MemberContainingGroups.Add(SingleGroup);
            }

            return vm;
        }

        public async Task<PersonalLoanFormViewModel> MemberLoanWithGroups(long memberNID, int groupId)
        {
            var memberDetails = await context.Members
                    .Where(x => x.NID == memberNID)
                    .Select(x => mapper.Map<SelectiveMemberDto>(x))
                    .SingleOrDefaultAsync();
            var group = await context.LoanGroups
                    .Where(x => x.LoanGroupId == groupId)
                    .Select(x => mapper.Map<LoanGroupDto>(x))
                    .SingleOrDefaultAsync();
            var subPeriod = await context.SubmissionPeriods.ToListAsync();
            var vm = new PersonalLoanFormViewModel
            {
                SelectedGroupId = groupId,
                SelectedGroupName = group.LoanGroupName,
                SelectedMemberNID = memberNID,
                SelectedMemberName = memberDetails.Name,
                SubmissionPeriod = new SelectList(subPeriod, "SubmissionPeriodDays", "SubmissionPeriodDays")
            };
            return vm;

        }

    }
}
