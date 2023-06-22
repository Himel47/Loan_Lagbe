using LoanData.DBContext;
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
        public LoanPlanService(MyContext context)
        {
            this.context = context;
        }


        public async Task<LoanPlanningViewModel> GetMainPage(int groupId)
        {
            var group = await context.LoanGroups.SingleOrDefaultAsync(x => x.LoanGroupId == groupId);
            var memberNids = await context.MembersWithGroups
                    .Where(x=>x.GroupId == groupId && x.GroupTypeId==1)
                    .Select(x=>x.MemberNID)
                    .ToListAsync();
            var subPeriod = await context.SubmissionPeriods.ToListAsync();
            var vm = new LoanPlanningViewModel
            {
                MemberList = new List<MemberBase>(),
                loanGroup = group,
                SubmissionPeriod = new SelectList(subPeriod, "SubmissionPeriodDays", "SubmissionPeriodDays")
            };

            foreach (var nid in memberNids)
            {
                var SingleMember = await context.Members.SingleOrDefaultAsync(x => x.NID == nid);
                if (SingleMember != null)
                {
                    vm.MemberList.Add(SingleMember);
                }
            }

            return vm;
        }

        //public async Task<LoanPlanningViewModel> PostMainPage(LoanPlanningViewModel model)
        //{
        //    var group = await context.LoanGroups.Where(x=>x.LoanGroupId==model.loanGroup.LoanGroupId).SingleOrDefaultAsync();
        //    if(group != null)
        //    {
        //        group.IsLoanPlanned = true;
        //    }
        //    foreach(var Loan in model.loanBasic)
        //    {
        //        var Installment = new InstallmentPayment
        //        {
        //            GroupId = Loan.GroupId,
        //            MemberId = Loan.MemberId,
        //            InstallmentCount = Loan.InstallmentCount,
        //            InstalmentAmount = Loan.PerInstallmentAmount,
        //            InstallmentDays = Loan.InstallmentDays
        //        };
        //        await context.Installments.AddAsync(Installment);
        //    }
        //    var response = await context.SaveChangesAsync();
        //    return model;
        //}

        public async Task<List<MemberBase>> MemberSelectForLoanPlan()
        {
            var MemberList = await context.Members.ToListAsync();
            return MemberList;
        }

        public async Task<PersonalLoanViewModel> MemberLoanWithGroups(long MemberNID, int groupId)
        {
            var memberDetails = await context.Members
                .Where(x => x.NID == MemberNID)
                .SingleOrDefaultAsync();
            var subPeriod = await context.SubmissionPeriods.ToListAsync();
            var vm = new PersonalLoanViewModel
            {
                MemberContainingGroups = new(),
                SelectedGroupId = groupId,
                SelectedMemberNID = MemberNID,
                SubmissionPeriod = new SelectList(subPeriod, "SubmissionPeriodDays", "SubmissionPeriodDays")
            };
            if (groupId == 0)
            {
                var SelectedGroups = await context.MembersWithGroups
                    .Where(x=>x.MemberNID== MemberNID && x.GroupTypeId == 1)
                    .Select(x => x.GroupId).ToListAsync();
                foreach (var SinglegroupId in SelectedGroups)
                {
                    var SingleGroup = await context.LoanGroups
                        .Where(x => x.LoanGroupId == SinglegroupId)
                        .SingleOrDefaultAsync();
                    if(SingleGroup != null)
                    {
                        vm.MemberContainingGroups.Add(SingleGroup);
                    }
                }
            }
            else
            {
                var SingleGroup = await context.LoanGroups
                        .Where(x => x.LoanGroupId == groupId)
                        .SingleOrDefaultAsync();
                if (SingleGroup != null)
                {
                    vm.MemberContainingGroups.Add(SingleGroup);
                }
            }
            if(memberDetails != null)
            {
                vm.SelectedMember = memberDetails;
            }
            return vm;
        }

        public async Task<PersonalLoanViewModel> MemberLoanWithGroups(PersonalLoanViewModel model)
        {
            //if (model != null)
            //{
            //    var LoanDetails = new LoanBasic
            //    {
            //        LoanAmount = model.LoanBasic.
            //    };
            //    await context.LoanDetails.AddAsync();
            //}
            return null;
        }

    }
}
