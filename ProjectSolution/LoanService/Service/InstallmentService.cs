using AutoMapper;
using LoanData.DBContext;
using LoanData.Models.Loan;
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

        public async Task<List<InstallmentPayment>> PersonalLoanSchedule(int groupId, long nid, int loanId)
        {
            var response = await context.LoanPersonalInstallments
                .Where(x => x.GroupId == groupId &&
                    x.LoanId == loanId &&
                    x.MemberNID == nid)
                .ToListAsync();

            return response;
        }

        public async Task<InstallmentPayment> SubmitInstallment(int groupId, long nid, int loanId, int installmentId)
        {
            var response = await context.LoanPersonalInstallments
                .Where(x => x.GroupId == groupId &&
                    x.LoanId == loanId &&
                    x.InstallmentId == installmentId &&
                    x.MemberNID == nid)
                .SingleOrDefaultAsync();

            if (response == null)
            {
                return null;
            }
            return response;

        }


    }
}
