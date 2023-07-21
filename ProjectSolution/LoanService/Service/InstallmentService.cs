using AutoMapper;
using LoanData.DBContext;
using LoanData.DTOs;
using LoanData.Models.Loan;
using LoanData.ViewModels;
using LoanService.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Service
{
    public class InstallmentService : IInstallmentService
    {
        private readonly MyContext context;
        private readonly IMapper mapper;

        public InstallmentService(MyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<InstallmentPayment>> AllInstallmentSchedule()
        {
            var response = await context.LoanPersonalInstallments.ToListAsync();
            return response;
        }

        public async Task<PersonalInstallmentViewModel> PersonalLoanSchedule(int groupId, long nid, int loanId)
        {
            var response = await context.LoanPersonalInstallments
                .Where(x => x.GroupId == groupId &&
                    x.LoanId == loanId &&
                    x.MemberId == nid)
                .ToListAsync();

            var member = await context.Members
                .Where(x => x.NID == nid)
                .Select(x => mapper.Map<SelectiveMemberDto>(x))
                .SingleOrDefaultAsync();

            var group = await context.LoanGroups
                .Where(x => x.LoanGroupId == groupId)
                .Select(x => mapper.Map<LoanGroupDto>(x))
                .SingleOrDefaultAsync();

            var vm = new PersonalInstallmentViewModel
            {
                PersonalInstallments = new(),
                MemberName = member.Name,
                GroupName = group.LoanGroupName
            };

            vm.PersonalInstallments = response;

            return vm;
        }

        public async Task<InstallmentPayment> SubmitInstallment(int groupId, long nid, int loanId, int installmentId)
        {
            var response = await context.LoanPersonalInstallments
                .Where(x => x.GroupId == groupId &&
                    x.LoanId == loanId &&
                    x.InstallmentId == installmentId &&
                    x.MemberId == nid)
                .SingleOrDefaultAsync();

            if (response == null)
            {
                return null;
            }
            return response;

        }


    }
}
