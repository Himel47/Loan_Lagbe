using LoanData.ViewModels;
using LoanService.ServiceInterface.Api;
using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IApiGroupService groupService;

        public GroupsController(IApiGroupService groupService)
        {
            this.groupService = groupService;
        }


        [HttpPost]
        public async Task<JsonResult> AddGroup([FromForm] GroupCreatingViewModel model)
        {
            var response = await groupService.AddNewGroup(model);

            int groupId = model.Id, groupTypeId = model.GrouptypeId;
            if (response == 0 || response == 1)
            {
                return new JsonResult(BadRequest());
            }

            var jsonResponse = new
            {
                groupId = groupId,
                groupTypeId = groupTypeId,
                value = "Group Created Successfully!"
            };

            return new JsonResult(jsonResponse);
        }


    }
}
