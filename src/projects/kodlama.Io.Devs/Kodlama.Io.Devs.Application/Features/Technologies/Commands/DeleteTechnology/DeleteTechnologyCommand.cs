using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Kodlama.Io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand:IRequest<DeleteTechnologyDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } = { "Admin" };


        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeleteTechnologyDto>
        {
            IMapper _mapper;
            ITechnologyRepository _technologyRepository;

            public DeleteTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<DeleteTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology deletedTechnology = await _technologyRepository.DeleteAsync(mappedTechnology);
                DeleteTechnologyDto deleteTechnology = _mapper.Map<DeleteTechnologyDto>(deletedTechnology);
                return deleteTechnology;
            }
        }
    }
}
