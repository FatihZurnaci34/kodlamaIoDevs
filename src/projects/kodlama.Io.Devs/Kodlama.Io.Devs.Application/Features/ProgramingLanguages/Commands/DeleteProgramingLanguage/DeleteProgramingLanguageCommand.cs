using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage
{
    public class DeleteProgramingLanguageCommand:IRequest<DeleteProgramingLanguageDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } = { "Admin" };

        public class DeleteProgramingLanguageHandler : IRequestHandler<DeleteProgramingLanguageCommand, DeleteProgramingLanguageDto>
        {
            IProgramingLanguageRepository _programingLanguageRepository;
            IMapper _mapper;

            public DeleteProgramingLanguageHandler(IProgramingLanguageRepository programingLanguageRepository, IMapper mapper)
            {
                _programingLanguageRepository = programingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<DeleteProgramingLanguageDto> Handle(DeleteProgramingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgramingLanguage mappedProgramingLanguage = _mapper.Map<ProgramingLanguage>(request);
                ProgramingLanguage deletedProgramingLanguage = await _programingLanguageRepository.DeleteAsync(mappedProgramingLanguage);
                DeleteProgramingLanguageDto deleteProgramingLanguage = _mapper.Map<DeleteProgramingLanguageDto>(deletedProgramingLanguage);
                return deleteProgramingLanguage;
            }
        }
    }
}
