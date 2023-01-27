using FluentValidation;
using Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage
{
    public class CreateProgramingLanguageCommandValidator : AbstractValidator<CreateProgramingLanguageDto>
    {
        public CreateProgramingLanguageCommandValidator()
        {
            RuleFor(p=>p.Name).NotEmpty();
        }
        
    }
}
