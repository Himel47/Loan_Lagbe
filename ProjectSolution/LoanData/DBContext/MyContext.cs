using LoanData.Models;
using LoanData.Models.Group;
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
        public DbSet<LoanGroup> LoanGroups { get; set; }
        public DbSet<CollectionGroup> CollectionGroups { get; set; }
        public DbSet<SubmissionPeriod> SubmissionPeriods { get; set; }
        public DbSet<GroupType> GroupTypes { get; set; }
        public DbSet<MemberWithGroup> MembersWithGroups { get; set; }
    }
}
