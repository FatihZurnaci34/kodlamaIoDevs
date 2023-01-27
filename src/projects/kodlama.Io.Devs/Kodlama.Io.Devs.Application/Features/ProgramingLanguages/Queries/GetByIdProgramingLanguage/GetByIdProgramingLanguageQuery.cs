using AutoMapper;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Queries.GetByIdProgramingLanguage
{
    public class GetByIdProgramingLanguageQuery:IRequest<ProgramingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdProgramingLanguageQueryHandler : IRequestHandler<GetByIdProgramingLanguageQuery, ProgramingLanguageGetByIdDto>
        {
            IMapper _mapper;
            IProgramingLanguageRepository _programingLanguageRepository;
            ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public GetByIdProgramingLanguageQueryHandler(IMapper mapper, IProgramingLanguageRepository programingLanguageRepository, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _mapper = mapper;
                _programingLanguageRepository = programingLanguageRepository;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<ProgramingLanguageGetByIdDto> Handle(GetByIdProgramingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(p=>p.Id==request.Id);
                _programingLanguageBusinessRules.BrandShouldExistWhenRequested(programingLanguage);
                ProgramingLanguageGetByIdDto programingLanguageGetByIdDto = _mapper.Map<ProgramingLanguageGetByIdDto>(programingLanguage);
                return programingLanguageGetByIdDto;
            }
        }
    }

}
