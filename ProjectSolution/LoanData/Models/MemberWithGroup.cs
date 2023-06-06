using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.Models
{
    public class MemberWithGroup
    {
        [Key]
        public long Id { get; set; }
        public int GroupTypeId { get; set; }
        public int GroupId { get; set; }
        public long MemberNID { get; set; }
    }
}
