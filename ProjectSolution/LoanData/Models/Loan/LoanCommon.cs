namespace LoanData.Models.Loan
{
    public class LoanCommon
    {
        public long MemberNID { get; set; }
        public string MemberName { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; }
    }
}
