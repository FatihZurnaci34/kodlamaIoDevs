using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Models;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Profiles
{
    public class MapingProfile:Profile
    {
        public MapingProfile()
        {
            CreateMap<ProgramingLanguage, CreateProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, CreateProgramingLanguageCommand>().ReverseMap();

            CreateMap<ProgramingLanguage, UpdateProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, UpdateProgramingLanguageCommand>().ReverseMap();

            CreateMap<ProgramingLanguage, DeleteProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, DeleteProgramingLanguageCommand>().ReverseMap();

            CreateMap<ProgramingLanguage, ProgramingLanguageGetByIdDto>().ReverseMap();

            CreateMap<ProgramingLanguage, ProgramingLanguageListDto>().ReverseMap();
            CreateMap < IPaginate<ProgramingLanguage>, ProgramingLanguageListModel>().ReverseMap();
        }
    }
}
