using LoanData.ViewModels;
using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }


        [HttpGet]
        public IActionResult LoanIndex()
        {
            var groups = groupService.LoanGroupListAsync();
            return View(groups);
        }

        [HttpGet]
        public IActionResult CollectionIndex()
        {
            var groups = groupService.CollectionGroupListAsync();
            return View(groups);
        }

        [HttpGet]
        public async Task<IActionResult> AddGroup()
        {
            var groupCreation = await groupService.AddNewGroupAsync();

            return View(groupCreation);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupDetails(int groupId, int groupTypeId)
        {
            var response = await groupService.GetGroupDetailsAsync(groupId, groupTypeId);

            if (response.LoanGroup == null && response.CollectionGroup == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> GroupMemberList(int groupId, int groupTypeId)
        {
            var response = await groupService.GroupMemberListAsync(groupId, groupTypeId);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> MemberWithGroup(int groupId, int groupTypeId)
        {
            var response = await groupService.AddMemberToGroupAsync(groupId, groupTypeId);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> EditGroupInfo(int groupId, int groupTypeId)
        {
            var response = await groupService.EditGroupDetailsAsync(groupId, groupTypeId);
            if (response.LoanGroup == null && response.CollectionGroup == null)
            {
                return NotFound();
            }
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditGroupInfo(GroupDetailsViewModel model)
        {
            var response = await groupService.EditGroupDetailsAsync(model);
            if (response.GroupTypeId == 1)
            {
                return RedirectToAction("LoanIndex");
            }
            else if (response.GroupTypeId == 2)
            {
                return RedirectToAction("CollectionIndex");
            }
            return BadRequest();
        }


        // Adding Member Portion with groupTypeId

        [HttpGet]
        public IActionResult HeadingLoanGroup()
        {
            var response = groupService.LoanGroupSelection();
            return RedirectToAction("MemberWithGroup", new { response.GroupId, groupTypeId = response.GroupTypeId });
        }

        [HttpGet]
        public IActionResult HeadingCollectionGroup()
        {
            var response = groupService.CollectionGroupSelection();
            return RedirectToAction("MemberWithGroup", new { response.GroupId, groupTypeId = response.GroupTypeId });
        }
    }
}
