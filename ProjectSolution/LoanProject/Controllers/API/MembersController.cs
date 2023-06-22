using LoanData.ViewModels;
using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IApiGroupService groupService;

        public MembersController(IApiGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        public async Task<JsonResult> AddMemberToGroup([FromForm] AddMemberToGroupViewModel model)
        {
            var response = await groupService.AddMemberToGroup(model);
            if (response != null)
            {
                return new JsonResult(Ok("Members are Added Successfully!"));
            }
            return new JsonResult(BadRequest());
        }
    }
}
