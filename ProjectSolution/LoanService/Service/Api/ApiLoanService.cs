﻿using LoanData.DBContext;
using LoanData.Models.Loan;
using LoanService.ServiceInterface.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Service.Api
{
    public class ApiLoanService : IApiLoanService
    {
        private readonly MyContext context;

        public ApiLoanService(MyContext context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<Installment>> GetAllLoans()
        {
            var loanList = await context.InstallmentDetails.ToListAsync();
            return loanList;
        }

        public async Task<JsonResult> SubmitLoanPlan(LoanBasic loan)
        {
            // InstallmentDetails table
            var Loan = new Installment
            {
                GroupId = loan.GroupId,
                MemberId = loan.MemberId,
                InstallmentCount = loan.InstallmentCount,
                InstallmentDays = loan.InstallmentDays,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMonths(loan.SubmissionTimeInMonth),
            };
            await context.InstallmentDetails.AddAsync(Loan);
            await context.SaveChangesAsync();

            // LoanDetails table
            var thisLoanId = await context.InstallmentDetails
                .Where(x => x.GroupId == Loan.GroupId &&
                    x.MemberId == Loan.MemberId)
                .Select(x => x.Id)
                .SingleOrDefaultAsync();

            loan.SerialId = thisLoanId;
            loan.EndTime = DateTime.Now.AddMonths(loan.SubmissionTimeInMonth);

            await context.LoanDetails.AddAsync(loan);

            await InstallmentSchedule(loan);

            await context.SaveChangesAsync();

            return new JsonResult("Loan Created Successfully!");

        }

        public async Task<JsonResult> InstallmentSchedule(LoanBasic loan)
        {
            // PersonalInstallments table

            var perInstallmentStartTime = DateTime.Now;
            var perInstallmentEndTime = DateTime.Now.AddDays(loan.InstallmentDays);
            int installmentDays = loan.InstallmentDays;

            ;

            for (int counter = 1; counter < loan.InstallmentCount + 1; counter++)
            {
                var installment = new InstallmentPayment
                {
                    LoanId = loan.SerialId,
                    InstalmentAmount = loan.PerInstallmentAmount,
                    PaidAmount = 0,
                    RemainingAmount = loan.PerInstallmentAmount,
                    GroupId = loan.GroupId,
                    MemberId = loan.MemberId,
                    StartTime = perInstallmentStartTime,
                    EndTime = perInstallmentEndTime,
                    InstallmentId = counter
                };


                await context.LoanPersonalInstallments.AddAsync(installment);

                perInstallmentStartTime = perInstallmentEndTime;
                perInstallmentEndTime = perInstallmentEndTime.AddDays(installmentDays);
            }


            return new JsonResult("Ok");
        }
    }
}