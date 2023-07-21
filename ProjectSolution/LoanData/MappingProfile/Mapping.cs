using AutoMapper;
using LoanData.DTOs;
using LoanData.Models.Group;
using LoanData.Models.Member;

namespace LoanData.MappingProfile
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<MemberBase, SelectiveMemberDto>();
            CreateMap<SelectiveMemberDto, MemberBase>();
            CreateMap<LoanGroup, LoanGroupDto>();
            CreateMap<LoanGroupDto, LoanGroup>();
        }
    }
}
