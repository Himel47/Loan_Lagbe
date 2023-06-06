using LoanData.Models.Member;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.Models.Group
{
    public class CollectionGroup
    {
        [Key]
        public int CollectionGroupId { get; set; }

        [Required]
        [Display(Name ="Group Name")]
        [MaxLength(150)]
        public string CollectionGroupName { get; set; }

        [Required]
        [Display(Name = "Time of group creation")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        [Required]
        [StringLength(128)]
        [Display(Name = "Group Forming Location")]
        public string Location { get; set; }

        public MemberBase? Member { get; set; }
        public int CollectedMoney { get; set; } = 0;
    }
}
