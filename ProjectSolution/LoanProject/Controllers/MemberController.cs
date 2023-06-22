using LoanData;
using LoanData.Models.Member;
using LoanData.ViewModels;
using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace LoanProject.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var members = await memberService.GetMembersAsync();
            return View(members);
        }

        [HttpGet]
        public async Task<IActionResult> AddMember()
        {
            var response = await memberService.AddMemberAsync();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(CreatingMemberViewModel model)
        {
            var response = await memberService.AddMemberAsync(model);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public async Task<IActionResult> AddMemberToGroup()
        //{
        //    var SelectionGroup = await memberService.AddMemberToGroupAsync();

        //    return View(SelectionGroup);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddMemberToGroup(AddMemberToGroupViewModel groupViewModel)
        //{
        //    var selectedGroup = groupViewModel.SelectedGroup;
        //
        //    return RedirectToAction("Index");
        //}


        [HttpGet]
        public async Task<IActionResult> MemberDetails(long nid)
        {
            var response = await memberService.GetMemberDetailsAsync(nid);

            if(response == null)
            {
                return NotFound();
            }

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditDetails(CreatingMemberViewModel model)
        {
            await memberService.EditMemberDetails(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditDetails(long nid)
        {
            var response = await memberService.EditMemberDetails(nid);
            return await Task.Run(() => View("EditDetails", response));
        }
    }
}
