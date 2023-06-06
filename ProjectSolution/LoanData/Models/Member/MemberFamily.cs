using System.ComponentModel.DataAnnotations;

namespace LoanData.Models.Member
{
    public class MemberFamily
    {
        public string? FatherName { get; set; }
        public string? MotherName { get; set; }
        public int TotalFamilyMember { get; set; }
        [Required(ErrorMessage ="Required!")]
        public int NoOfEarningMember { get; set; }
        [Required(ErrorMessage ="Required!")]
        public int MonthlyIncome { get; set; }
    }
}
