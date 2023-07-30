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

            //var groupIds = await context.InstallmentDetails
            //    .Where(x => x.MemberId == memberNid)
            //    .Select(x => x.GroupId)
            //    .ToListAsync();

            var vm = new LoanPlanGroupSelectionViewModel
            {
                MemberContainingGroups = new(),
                LoanTakenGroupIds = new(),
                Member = singleMember
            };
            //vm.LoanTakenGroupIds = groupIds;

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

        public async Task<List<LoanGroupDto>> SelectingGroupForLoan()
        {
            var response = await context.LoanGroups
                .Select(x => mapper.Map<LoanGroupDto>(x))
                .ToListAsync();

            return response;
        }

        public async Task<GroupLoanFormViewModel> GroupLoanPlan(int groupId)
        {
            var group = await context.LoanGroups
                .Where(x => x.LoanGroupId == groupId)
                .Select(x => mapper.Map<LoanGroupDto>(x))
                .SingleOrDefaultAsync();

            var groupMemberNids = await context.MembersWithGroups
                .Where(x => x.GroupId == groupId &&
                    x.GroupTypeId == 1)
                .Select(x => x.MemberNID)
                .ToListAsync();

            var submissionPeriod = await context.SubmissionPeriods.ToListAsync();

            var vm = new GroupLoanFormViewModel
            {
                SelectedGroupId = group.LoanGroupId,
                SelectedGroupName = group.LoanGroupName,
                GroupMemebrs = new(),
                SubmissionPeriod = new SelectList(submissionPeriod, "SubmissionPeriodDays", "SubmissionPeriodDays")
            };

            foreach (var member in groupMemberNids)
            {
                var memberDetails = await context.Members
                    .Where(x => x.NID == member)
                    .Select(x => mapper.Map<SelectiveMemberDto>(x))
                    .SingleOrDefaultAsync();
                if (memberDetails != null)
                {
                    vm.GroupMemebrs.Add(memberDetails);
                }

            }

            return vm;
        }

        public async Task<IList<LoanBasic>> GroupLoanPlanSubmit(IList<LoanBasic> loans)
        {
            decimal totalLoan = 0;
            foreach (var loan in loans)
            {
                totalLoan += loan.LoanAmount;
                loan.StartTime = DateTime.Now;
                loan.EndTime = DateTime.Now.AddMonths(loan.SubmissionTimeInMonth);

                await context.LoanDetails.AddAsync(loan);

                var installment = new Installment
                {
                    GroupId = loan.GroupId,
                    GroupName = loan.GroupName,
                    MemberNID = loan.MemberNID,
                    MemberName = loan.MemberName,
                    StartTime = loan.StartTime,
                    EndTime = loan.EndTime,
                    InstallmentCount = loan.InstallmentCount,
                    InstallmentDays = loan.InstallmentDays
                };
                await context.InstallmentDetails.AddAsync(installment);

            }

            var loanGroup = await context.LoanGroups
                .Where(x => x.LoanGroupId == loans[0].GroupId)
                .SingleOrDefaultAsync();
            loanGroup.TotalLoanAmount = totalLoan;

            await InstallmentCreation(loans);

            await context.SaveChangesAsync();

            return loans;
        }

        public async Task<IList<LoanBasic>> InstallmentCreation(IList<LoanBasic> loans)
        {
            var loanGroup = await context.LoanDetails.
                Where(x => x.GroupId == loans[0].GroupId)
                .Select(x => x.LoanId)
                .SingleOrDefaultAsync();

            foreach (var loan in loans)
            {

                for (int i = 1; i < loan.InstallmentCount; i++)
                {
                    var installmentPayment = new InstallmentPayment
                    {
                        GroupId = loan.GroupId,
                        GroupName = loan.GroupName,
                        MemberNID = loan.MemberNID,
                        MemberName = loan.MemberName,
                        StartTime = loan.StartTime,
                        EndTime = loan.EndTime,
                        InstallmentId = i,
                        InstalmentAmount = loan.PerInstallmentAmount,
                        PaidAmount = 0,
                        RemainingAmount = loan.PerInstallmentAmount
                    };

                    await context.LoanPersonalInstallments.AddAsync(installmentPayment);
                }
            }

            return loans;
        }



    }
}
