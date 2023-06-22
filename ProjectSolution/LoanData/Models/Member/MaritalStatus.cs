using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanData.Models.Member
{
    public class MaritalStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string MaritalStatusName { get; set; }
    }
}
