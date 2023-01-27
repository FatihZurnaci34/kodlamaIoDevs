using FluentValidation;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommandValidator : AbstractValidator<UpdateTechnologyDto>
    {
        public UpdateTechnologyCommandValidator()
        {
            RuleFor(t=>t.Name).NotEmpty();
        }
    }
}
