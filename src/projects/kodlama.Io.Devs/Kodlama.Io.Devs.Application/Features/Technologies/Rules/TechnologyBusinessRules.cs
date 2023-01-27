using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(x => x.Name == name);
            if (result.Items.Any()) throw new BusinessException("Technology name exists.");

        }
        public void TechnologyShouldExistWhenRequested(ProgramingLanguage programingLanguage)
        {
            if (programingLanguage == null) throw new BusinessException("Requested programming language does not exist");
        }
    }
}
