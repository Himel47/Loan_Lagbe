using LoanData.DBContext;
using LoanData.Models.Group;
using LoanData.Models.Member;
using LoanData.ViewModels;
using LoanService.ServiceInterface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LoanService.Service
{
    public class GroupService : IGroupService
    {
        private readonly MyContext context;
        public GroupService(MyContext context)
        {
            this.context = context;
        }


        public List<LoanGroup> LoanGroupListAsync()
        {
            var LoanGroups = context.LoanGroups.ToList();
            return LoanGroups;
        }

        public List<CollectionGroup> CollectionGroupListAsync()
        {
            var CollectionGroups = context.CollectionGroups.ToList();
            return CollectionGroups;
        }

        public async Task<GroupCreatingViewModel> AddNewGroupAsync()
        {
            var groupTypes = await context.GroupTypes.ToListAsync();

            var vm = new GroupCreatingViewModel
            {
                GroupTypeList = new SelectList(groupTypes, "TypeId", "GroupTypeName")
            };

            return vm;
        }

        public async Task<GroupCreatingViewModel> AddNewLoanGroupAsync(GroupCreatingViewModel model)
        {
            var group = new LoanGroup
            {
                LoanGroupName = model.Group.GroupName,
                Location = model.Group.Location,
                CreatedAt = model.Group.CreatedAt
            };
            var loan = await context.LoanGroups.AddAsync(group);
            context.SaveChanges();
            var response = await context.LoanGroups.FirstOrDefaultAsync(x=>x.LoanGroupName == model.Group.GroupName);
            model.Id = response.LoanGroupId;
            return model;
        }

        public async Task<GroupCreatingViewModel> AddNewCollectionGroupAsync(GroupCreatingViewModel model)
        {
            var group = new CollectionGroup
            {
                CollectionGroupName = model.Group.GroupName,
                Location = model.Group.Location,
                CreatedAt = model.Group.CreatedAt
            };
            var loan = await context.CollectionGroups.AddAsync(group);
            context.SaveChanges();
            var response = await context.CollectionGroups.FirstOrDefaultAsync(x => x.CollectionGroupName == model.Group.GroupName);
            model.Id = response.CollectionGroupId;
            return model;
        }

        public async Task<MemberWithGroupViewModel> AddMemberToGroupAsync(int GroupId, int groupTypeId)
        {
            var loanGroup = new LoanGroup();
            var collectionGroup = new CollectionGroup();
            
            var vm = new MemberWithGroupViewModel();
            
            if (groupTypeId == 1)
            {
                loanGroup = await context.LoanGroups.FirstOrDefaultAsync(x => x.LoanGroupId == GroupId);
                if (GroupId == 0)
                {
                    var allGroups = await context.LoanGroups.ToListAsync();
                    vm.AllGroups = new SelectList(allGroups, "LoanGroupId", "LoanGroupName");
                    vm.GroupId = 0;
                }
                else
                {
                    vm.GroupName = loanGroup.LoanGroupName;
                    vm.GroupId = loanGroup.LoanGroupId;
                }
                vm.GroupTypeId = groupTypeId;
            }
            else if(groupTypeId == 2)
            {
                collectionGroup = await context.CollectionGroups.FirstOrDefaultAsync(x => x.CollectionGroupId == GroupId);
                if (GroupId == 0)
                {
                    var allGroups = await context.CollectionGroups.ToListAsync();
                    vm.AllGroups = new SelectList(allGroups, "CollectionGroupId", "CollectionGroupName");
                    vm.GroupId = 0;
                }
                else
                {
                    vm.GroupName = collectionGroup.CollectionGroupName;
                    vm.GroupId = collectionGroup.CollectionGroupId;
                }
                vm.GroupTypeId = groupTypeId;
            }
            else
            {
                var allGroupTypes = await context.GroupTypes.ToListAsync();
                vm.GroupTypes = new SelectList(allGroupTypes,"TypeId","GroupTypeName");
            }
            vm.MembersList = await context.Members.ToListAsync();
            return vm;
        }

        public async Task<GroupDetailsViewModel> GetGroupDetailsAsync(int id, int groupTypeId)
        {
            var vm = new GroupDetailsViewModel
            {
                Id = id,
                GroupTypeId = groupTypeId
            };
            if (groupTypeId == 1)
            {
                vm.LoanGroup = await context.LoanGroups.Where(x => x.LoanGroupId == id).FirstOrDefaultAsync();
            }
            else if(groupTypeId == 2)
            {
                vm.CollectionGroup = await context.CollectionGroups.Where(x => x.CollectionGroupId == id).FirstOrDefaultAsync();
            }
            return vm;
        }

        public async Task<MemberWithGroupViewModel> GroupMemberListAsync(int groupId, int groupTypeId)
        {
            var groupMembers = await context.MembersWithGroups
                .Where(x=>x.GroupId == groupId && x.GroupTypeId == groupTypeId)
                .Select(x=>x.MemberNID).ToListAsync();

            var vm = new MemberWithGroupViewModel
            {
                GroupId = groupId,
                GroupTypeId= groupTypeId,
            };
            if (groupTypeId == 1)
            {
                var group = await context.LoanGroups.Where(x=>x.LoanGroupId == groupId).SingleOrDefaultAsync();
                vm.GroupName = group.LoanGroupName;
            }
            else if(groupTypeId == 2)
            {
                var group = await context.CollectionGroups.Where(x => x.CollectionGroupId == groupId).SingleOrDefaultAsync();
                vm.GroupName = group.CollectionGroupName;
            }
            vm.MembersList = new List<MemberBase>();
            foreach (var memberNid in groupMembers)
            {
                var member = await context.Members.Where(x => x.NID == memberNid).SingleOrDefaultAsync();
                if (member != null)
                {
                    vm.MembersList.Add(member);
                }
            }
            return vm;
        }

        public async Task<GroupDetailsViewModel> EditGroupDetailsAsync(int id, int groupTypeId)
        {
            var vm = new GroupDetailsViewModel
            {
                Id = id,
                GroupTypeId = groupTypeId
            };
            if (groupTypeId == 1)
            {
                vm.LoanGroup = await context.LoanGroups.Where(x => x.LoanGroupId == id).FirstOrDefaultAsync();
            }
            else if (groupTypeId == 2)
            {
                vm.CollectionGroup = await context.CollectionGroups.Where(x => x.CollectionGroupId == id).FirstOrDefaultAsync();
            }
            return vm;
        }

        public async Task<GroupDetailsViewModel> EditGroupDetailsAsync(GroupDetailsViewModel model)
        {
            if (model.LoanGroup != null)
            {
                model.GroupTypeId = 1;
                var response = await context.LoanGroups.FindAsync(model.LoanGroup.LoanGroupId);
                model.GroupId = model.LoanGroup.LoanGroupId;
                if (response != null)
                {
                    response.LoanGroupName = model.LoanGroup.LoanGroupName;
                    response.Location = model.LoanGroup.Location;
                    response.UpdatedAt = DateTime.Now;
                }
            }
            else if (model.CollectionGroup != null)
            {
                model.GroupTypeId = 2;
                var response = await context.CollectionGroups.FindAsync(model.CollectionGroup.CollectionGroupId);
                model.GroupId = model.CollectionGroup.CollectionGroupId;
                if (response != null)
                {
                    response.CollectionGroupName = model.CollectionGroup.CollectionGroupName;
                    response.Location = model.CollectionGroup.Location;
                    response.UpdatedAt = DateTime.Now;
                }
            }
            await context.SaveChangesAsync();
            return model;
        }
        
        public MemberWithGroupViewModel LoanGroupSelection()
        {
            return new MemberWithGroupViewModel
            {
                GroupTypeId = 1
            };
        }

        public MemberWithGroupViewModel CollectionGroupSelection()
        {
            return new MemberWithGroupViewModel
            {
                GroupTypeId = 2
            };
        }

        public bool Save()
        {
            context.SaveChanges();
            return true;
        }
    }
}
