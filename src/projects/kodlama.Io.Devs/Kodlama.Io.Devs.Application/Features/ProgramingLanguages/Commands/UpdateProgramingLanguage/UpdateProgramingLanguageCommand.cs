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

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage
{
    public class UpdateProgramingLanguageCommand:IRequest<UpdateProgramingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public class UpdateProgramingLanguageHandler : IRequestHandler<UpdateProgramingLanguageCommand, UpdateProgramingLanguageDto>
        {
            IProgramingLanguageRepository _programingLanguageRepository;
            IMapper _mapper;
            ProgramingLanguageBusinessRules _programingLanguageBusinessRules;

            public UpdateProgramingLanguageHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper, ProgramingLanguageBusinessRules programingLanguageBusinessRules)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
                _programingLanguageBusinessRules = programingLanguageBusinessRules;
            }

            public async Task<UpdateProgramingLanguageDto> Handle(UpdateProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programingLanguageBusinessRules.ProgramingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgramingLanguage? programingLanguage = await _programingLanguageRepository.GetAsync(b => b.Id == request.Id);
                ProgramingLanguage? mappedProgramingLanguage = _mapper.Map(request, programingLanguage);
                ProgramingLanguage updatedProgramingLanguage = await _programingLanguageRepository.UpdateAsync(mappedProgramingLanguage);
                UpdateProgramingLanguageDto updateProgramingLanguage = _mapper.Map<UpdateProgramingLanguageDto>(updatedProgramingLanguage);
                return updateProgramingLanguage;

            }
        }
    }
}
