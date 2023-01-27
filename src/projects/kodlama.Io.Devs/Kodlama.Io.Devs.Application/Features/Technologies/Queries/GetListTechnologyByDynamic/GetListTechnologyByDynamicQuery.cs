using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.Technologies.Models;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Queries.GetListTechnologyByDynamic
{
    public class GetListTechnologyByDynamicQuery:IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyByDynamicQueryHanlder : IRequestHandler<GetListTechnologyByDynamicQuery, TechnologyListModel>
        {

            IMapper _mapper;
            ITechnologyRepository _technologyRepository;

            public GetListTechnologyByDynamicQueryHanlder(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> technologies = await _technologyRepository.GetListByDynamicAsync(
                    request.Dynamic, 
                    include: t => t.Include(x => x.ProgramingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                TechnologyListModel mappedTechnologies = _mapper.Map<TechnologyListModel>(technologies);
                return mappedTechnologies;
            }
        }
    }
}
