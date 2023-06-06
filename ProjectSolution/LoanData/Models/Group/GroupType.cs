using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.Models.Group
{
    public class GroupType
    {
        [Key]
        public int TypeId { get; set; }
        public string GroupTypeName { get; set; }
    }
}
