using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanData.Models.Member
{
    public class MemberBase : MemberMarital
    {
        [Key]
        [Required(ErrorMessage = "Identity Details Can't be Empty")]
        public long NID { get; set; }

        [Required(ErrorMessage = "You have to fill Name Field!")]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string? Phone { get; set; }
        public string? Occupation { get; set; }
        public string? Education { get; set; }
        public string? Institute { get; set; }
    }
}
