using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.CreateTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.DeleteTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Commands.UpdateTechnology;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.Io.Devs.Application.Features.Technologies.Models;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Technology,CreateTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

            CreateMap<Technology,UpdateTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<Technology,DeleteTechnologyDto>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();

            CreateMap<Technology, TechnologyGetByIdDto>()
                .ForMember(t => t.ProgramingLanguageName, opt => opt.MapFrom(t => t.ProgramingLanguage.Name)).ReverseMap();

            CreateMap<Technology, TechnologyListDto>()
                .ForMember(t => t.ProgramingLanguageName, opt => opt.MapFrom(t => t.ProgramingLanguage.Name)).ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        }
    }
}
