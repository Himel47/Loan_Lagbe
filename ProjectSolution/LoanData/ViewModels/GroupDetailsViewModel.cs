using LoanData.Models.Group;

namespace LoanData.ViewModels
{
    public class GroupDetailsViewModel
    {
        public int Id { get; set; }
        public int GroupId { get; set;}
        public int GroupTypeId { get; set; }
        public LoanGroup? LoanGroup { get; set; }
        public CollectionGroup? CollectionGroup { get; set; }
    }
}
