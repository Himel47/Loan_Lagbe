using LoanData.Models.Member;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LoanData.Models.Group
{
    public class Group
    {
        [Required(ErrorMessage = "Name is a Required Field!")]
        public string GroupName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage ="Location is a required Field")]
        [StringLength(128)]
        [Display(Name = "Group Forming Location")]
        public string Location { get; set; }
    }
}
