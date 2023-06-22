using LoanData;
using LoanData.DBContext;
using LoanData.Models.Member;
using LoanData.ViewModels;
using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        
        public async Task<List<NewMember>> GetMembersAsync()
        {
            var AllMembers =  await context.Members.ToListAsync();
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

        public async Task<CreatingMemberViewModel> AddMemberAsync()
        {
            var maritalStatus = await context.MaritalStatuses.ToListAsync();
            var vm = new CreatingMemberViewModel
            {
                MaritalStatus = new SelectList(maritalStatus, "MaritalStatusName", "MaritalStatusName")
            };
            return vm;
        }

        public async Task<CreatingMemberViewModel> AddMemberAsync(CreatingMemberViewModel model)
        {
            if(model.Member != null)
            {
                var newMember = new MemberBase
                {
                    Name = model.Member.Name,
                    NID = model.Member.NID,
                    DOB = model.Member.DOB,
                    Phone = model.Member.Phone,
                    Occupation = model.Member.Occupation,
                    Education = model.Member.Education,
                    Institute = model.Member.Institute,
                    MaritalStatus = model.Member.MaritalStatus,
                    SName = model.Member.SName,
                    SDOB = model.Member.SDOB,
                    SOccupation = model.Member.SOccupation,
                    FatherName = model.Member.FatherName,
                    MotherName = model.Member.MotherName,
                    TotalFamilyMember = model.Member.TotalFamilyMember,
                    NoOfEarningMember = model.Member.NoOfEarningMember,
                    MonthlyIncome = model.Member.MonthlyIncome
                };
                await context.AddAsync(newMember);
                var response = Save();
                if (response) return model;
            }
            return null;
        }

        public async Task<MemberBase> GetMemberDetailsAsync(long Nid)
        {
            var response =  await context.Members.Where(x=>x.NID == Nid).FirstOrDefaultAsync();
            return response;
        }

        public async Task<CreatingMemberViewModel> EditMemberDetails(long Nid)
        {
            var SingleMember = await context.Members.Where(x=>x.NID == Nid).FirstOrDefaultAsync();
            var MaritalStatus = await context.MaritalStatuses.ToListAsync();

            var vm = new CreatingMemberViewModel
            {
                MaritalStatus = new SelectList(MaritalStatus, "MaritalStatusName", "MaritalStatusName")
            };
            if (SingleMember != null)
            {
                vm.Member = SingleMember;
            }
            return vm;
        }

        public async Task<CreatingMemberViewModel> EditMemberDetails(CreatingMemberViewModel model)
        {
            var MemberData = await context.Members.FindAsync(model.Member.NID);
            if(MemberData != null)
            {
                MemberData.Name = model.Member.Name;
                MemberData.Phone = model.Member.Phone;
                MemberData.Occupation = model.Member.Occupation;
                MemberData.Education = model.Member.Education;
                MemberData.Institute = model.Member.Institute;
                MemberData.FatherName = model.Member.FatherName;
                MemberData.MotherName = model.Member.MotherName;
                MemberData.TotalFamilyMember = model.Member.TotalFamilyMember;
                MemberData.MaritalStatus = model.Member.MaritalStatus;
                MemberData.MonthlyIncome = model.Member.MonthlyIncome;
                MemberData.SName = model.Member.SName;
                MemberData.SDOB = model.Member.SDOB;
                MemberData.SOccupation = model.Member.SOccupation;
                MemberData.DOB = model.Member.DOB;
                MemberData.NoOfEarningMember = model.Member.NoOfEarningMember;
            }

            await context.SaveChangesAsync();
            return model;
        }

        private bool Save()
        {
            context.SaveChanges();
            return true;
        }
    }
}
