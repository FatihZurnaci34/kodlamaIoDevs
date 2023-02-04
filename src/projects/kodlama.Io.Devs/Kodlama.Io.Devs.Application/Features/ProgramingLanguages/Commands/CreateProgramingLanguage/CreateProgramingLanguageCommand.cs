using AutoMapper;
using Core.Application.Pipelines.Authorization;
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

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage
{
    public class CreateProgramingLanguageCommand : IRequest<CreateProgramingLanguageDto>,ISecuredRequest
    {
        public string Name { get; set; }
        public string[] Roles { get; } ={"Admin"};

        public class CreateProgramingLanguageHandler : IRequestHandler<CreateProgramingLanguageCommand, CreateProgramingLanguageDto>
        {
            private readonly IMapper _mapper;
            private readonly IProgramingLanguageRepository _programingLanguageRepository;
            private readonly ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public CreateProgramingLanguageHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<CreateProgramingLanguageDto> Handle(CreateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {

                await _programingLanguageBusinessRules.ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage createdProgramingLanguage = await _programingLanguageRepository.AddAsync(mappedProgramingLanguage);
                CreateProgramingLanguageDto createProgramingLanguageDto = _mapper.Map<CreateProgramingLanguageDto>(createdProgramingLanguage);

                return createProgramingLanguageDto;
            }


        }
    }
}
