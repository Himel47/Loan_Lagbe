using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LoanData.ViewModels
{
    public class GroupCreatingViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Group Name is Required!")]
        public string NewGroupName { get; set; }

        [Required(ErrorMessage = "Please give a location!")]
        public string GroupLocation { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please select a group type!")]
        public int GrouptypeId { get; set; }
        public SelectList? GroupTypeList { get; set; }
    }
}
