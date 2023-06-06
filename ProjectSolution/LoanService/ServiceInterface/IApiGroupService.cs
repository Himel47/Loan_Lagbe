using LoanData.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanService.ServiceInterface
{
    public interface IApiGroupService
    {
        public Task<JsonResult> AddMemberToGroup(AddMemberToGroupViewModel model);
    }
}
