using AutoMapper;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Kodlama.Io.Devs.Application.Features.OperationClaims.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class UpdateUserOperationClaimCommand:IRequest<UpdateOperationClaimDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationId { get; set; }

        public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdateOperationClaimDto>
        {
            IMapper _mapper;
            IUserOperationClaimRepository _userOperationClaimRepository;

            public UpdateUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UpdateOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {

                UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(u => u.Id == request.Id);
                UserOperationClaim mappedUserOperationClaim = _mapper.Map(request,userOperationClaim);
                UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
                UpdateOperationClaimDto updateUserOperationClaim = _mapper.Map<UpdateOperationClaimDto>(updatedUserOperationClaim);
                return updateUserOperationClaim;
                
            }
        }
    }
}
