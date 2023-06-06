using LoanData.Models.Member;
using System.ComponentModel.DataAnnotations;

namespace LoanData.Models.Group
{
    public class LoanGroup
    {
        [Key]
        public int LoanGroupId { get; set; }

        [Required]
        public string LoanGroupName { get; set; }

        [Required]
        [Display(Name = "Time of group creation")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Group Forming Location")]
        public string Location { get; set; }

        public MemberBase? Member { get; set; }
        public int TotalLoanAmount { get; set; } = 0;
    }
}
