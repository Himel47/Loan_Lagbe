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
        public IActionResult Index()
        {
            List<NewMember> members = memberService.GetMembersAsync();
            return View(members);
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(MemberBase member)
        {
            var response = await memberService.AddMemberAsync(member);
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
        public async Task<IActionResult> EditDetails(MemberBase member)
        {
            await memberService.EditMemberDetails(member);
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
