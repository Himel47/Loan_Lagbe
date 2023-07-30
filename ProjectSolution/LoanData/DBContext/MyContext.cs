using LoanData.Models;
using LoanData.Models.Group;
using LoanData.Models.Loan;
using LoanData.Models.Member;
using Microsoft.EntityFrameworkCore;

namespace LoanData.DBContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<MemberBase> Members { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<LoanGroup> LoanGroups { get; set; }
        public DbSet<CollectionGroup> CollectionGroups { get; set; }
        public DbSet<SubmissionPeriod> SubmissionPeriods { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<MemberWithGroup> MembersWithGroups { get; set; }
        public DbSet<LoanBasic> LoanDetails { get; set; }
        public DbSet<LoanPaidDetails> LoanPaymentDetails { get; set; }
        public DbSet<InstallmentPayment> LoanPersonalInstallments { get; set; }
        public DbSet<Installment> InstallmentDetails { get; set; }
        public DbSet<GroupLoan> GroupLoans { get; set; }
    }
}
