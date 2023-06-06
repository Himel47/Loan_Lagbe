using LoanData.Models.Group;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LoanData.ViewModels
{
    public class GroupCreatingViewModel
    {
        public int Id { get; set; }
        public Group Group { get; set; }

        [Required(ErrorMessage = "Please select a group type!")]
        public int GrouptypeId { get; set; }
        public SelectList GroupTypeList { get; set; }
    }
}
