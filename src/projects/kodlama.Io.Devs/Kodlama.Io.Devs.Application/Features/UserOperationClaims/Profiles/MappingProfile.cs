using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Commands.CreateUserOperationClaim;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.UserOperationClaims.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, UpdateUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim, DeleteUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();

            CreateMap<UserOperationClaim,UserOperationClaimGetByIdDto>()
                .ForMember(u=>u.UserName,opt=>opt.MapFrom(u=>u.User.FirstName))
                .ForMember(u=>u.OperationName,opt=>opt.MapFrom(u=>u.OperationClaim.Name)).ReverseMap();

            CreateMap<UserOperationClaim, UserOperationClaimListDto>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(u => u.User.FirstName))
                .ForMember(u => u.OperationName, opt => opt.MapFrom(u => u.OperationClaim.Name)).ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
        }
    }
}
