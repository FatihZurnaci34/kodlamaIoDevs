using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand:IRequest<UpdateOperationClaimDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Roles { get; } = { "Admin" };

        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdateOperationClaimDto>
        {
            IMapper _mapper;
            IOperationClaimRepository _operationClaimRepository;

            public UpdateOperationClaimCommandHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<UpdateOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await _operationClaimRepository.GetAsync(o => o.Id == request.Id);
                OperationClaim mappedOperationClaim = _mapper.Map(request,operationClaim);
                OperationClaim updatedOperationClam = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
                UpdateOperationClaimDto updateOperationClaim = _mapper.Map<UpdateOperationClaimDto>(updatedOperationClam);
                return updateOperationClaim;
            }
        }
    }
}
