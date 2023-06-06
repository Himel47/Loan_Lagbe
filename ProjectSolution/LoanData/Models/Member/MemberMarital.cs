using System.ComponentModel.DataAnnotations;

namespace LoanData.Models.Member
{
    public class MemberMarital : MemberFamily
    {
        [Required]
        public string MaritalStatus { get; set; }
        public string? SName { get; set; }
        public string? SDOB { get; set; }
        public string? SOccupation { get; set; }
    }
}
