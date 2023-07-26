using LoanData.DBContext;
using LoanData.Models.Loan;
using LoanService.ServiceInterface.Api;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Service.Api
{
    public class ApiInstallmentService : IApiInstallmentService
    {
        private readonly MyContext context;

        public ApiInstallmentService(MyContext context)
        {
            this.context = context;
        }

        public async Task<InstallmentPayment> PaymentParticularInstallment(InstallmentPayment installment)
        {
            if (installment == null)
            {
                return null;
            }

            if (installment.PaidAmount == installment.InstalmentAmount)
            {
                installment.IsPaid = true;
            }

            var response = await context.LoanPersonalInstallments
                .Where(x => x.MemberNID == installment.MemberNID &&
                    x.GroupId == installment.GroupId &&
                    x.LoanId == installment.LoanId &&
                    x.InstallmentId == installment.InstallmentId)
                .SingleOrDefaultAsync();

            if (response != null)
            {
                response.PaidAmount = installment.PaidAmount;
                response.IsPaid = installment.IsPaid;
                response.RemainingAmount = installment.RemainingAmount;
            }

            await context.SaveChangesAsync();


            return installment;
        }

    }
}
