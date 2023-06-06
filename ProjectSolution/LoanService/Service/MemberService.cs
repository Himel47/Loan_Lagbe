using LoanData;
using LoanData.DBContext;
using LoanData.Models.Member;
using LoanService.ServiceInterface;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Service
{
    public class MemberService: IMemberService
    {
        private readonly MyContext context;

        public MemberService(MyContext _Context)
        {
            context = _Context;
        }
        
        public List<NewMember> GetMembersAsync()
        {
            var AllMembers =  context.Members.ToList();
            List<NewMember> members = new();
            foreach (var member in AllMembers)
            {
                members.Add(new NewMember
                {
                    Name = member.Name,
                    NID = member.NID,
                    Phone = member.Phone,
                    MaritalStatus = member.MaritalStatus,
                    MonthlyIncome = member.MonthlyIncome
                });
            }
            return members;
        }

        public async Task<MemberBase> AddMemberAsync(MemberBase member)
        {
            if(member != null)
            {
                var newMember = new MemberBase
                {
                    Name = member.Name,
                    NID = member.NID,
                    DOB = member.DOB,
                    Phone = member.Phone,
                    Occupation = member.Occupation,
                    Education = member.Education,
                    Institute = member.Institute,
                    MaritalStatus = member.MaritalStatus,
                    FatherName = member.FatherName,
                    MotherName = member.MotherName,
                    TotalFamilyMember = member.TotalFamilyMember,
                    NoOfEarningMember = member.NoOfEarningMember,
                    MonthlyIncome = member.MonthlyIncome
                };
                await context.AddAsync(newMember);
                var response = Save();
                if (response) return newMember;
            }
            return null;
        }

        //public async Task<AddMemberToGroupViewModel> AddMemberToGroupAsync()
        //{
        //    var AllMembers = await context.Members.OrderBy(x => x.NID).ToListAsync();
        //    //var AllGroups = await context.Groups.OrderBy(x => x.Name).ToListAsync();
        //    var vm = new AddMemberToGroupViewModel();

        //    //vm.GroupSelectList = new SelectList(AllGroups, "Name", "Name");
        //    vm.MembersList = AllMembers;

        //    return vm;
        //}

        //public async Task<AddMemberToGroupViewModel> AddMemberToGroupAsync(AddMemberToGroupViewModel groupModel)
        //{
        //    return null;
        //}

        public async Task<MemberBase> GetMemberDetailsAsync(long Nid)
        {
            var response =  await context.Members.Where(x=>x.NID == Nid).FirstOrDefaultAsync();
            return response;
        }

        public async Task<MemberBase> EditMemberDetails(long Nid)
        {
            var response = await context.Members.Where(x=>x.NID == Nid).FirstOrDefaultAsync();

            if (response != null)
            {
                var viewModel = new MemberBase
                {
                    NID = response.NID,
                    Name = response.Name,
                    Phone = response.Phone,
                    Occupation = response.Occupation,
                    Education = response.Education,
                    Institute = response.Institute,
                    FatherName = response.FatherName,
                    MotherName = response.MotherName,
                    TotalFamilyMember = response.TotalFamilyMember,
                    MaritalStatus = response.MaritalStatus,
                    MonthlyIncome = response.MonthlyIncome,
                    SName = response.SName,
                    SDOB = response.SDOB,
                    SOccupation = response.SOccupation,
                    DOB = response.DOB,
                    NoOfEarningMember = response.NoOfEarningMember
                };
                return viewModel;
            }
            return null;
        }

        public async Task<MemberBase> EditMemberDetails(MemberBase response)
        {
            var MemberData = await context.Members.FindAsync(response.NID);
            if(MemberData != null)
            {
                MemberData.Name = response.Name;
                MemberData.Phone = response.Phone;
                MemberData.Occupation = response.Occupation;
                MemberData.Education = response.Education;
                MemberData.Institute = response.Institute;
                MemberData.FatherName = response.FatherName;
                MemberData.MotherName = response.MotherName;
                MemberData.TotalFamilyMember = response.TotalFamilyMember;
                MemberData.MaritalStatus = response.MaritalStatus;
                MemberData.MonthlyIncome = response.MonthlyIncome;
                MemberData.SName = response.SName;
                MemberData.SDOB = response.SDOB;
                MemberData.SOccupation = response.SOccupation;
                MemberData.DOB = response.DOB;
                MemberData.NoOfEarningMember = response.NoOfEarningMember;
            }

            await context.SaveChangesAsync();
            return MemberData;
        }

        private bool Save()
        {
            context.SaveChanges();
            return true;
        }
    }
}
