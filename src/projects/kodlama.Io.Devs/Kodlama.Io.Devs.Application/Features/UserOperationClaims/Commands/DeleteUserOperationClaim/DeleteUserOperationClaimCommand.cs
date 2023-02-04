using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.UserOperationClaims.Commands.DeleteUserOperationClaim
{
    public class DeleteUserOperationClaimCommand:IRequest<DeleteUserOperationClaimDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles { get; } = { "Admin" };

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeleteUserOperationClaimDto>
        {
            IMapper _mapper;
            IUserOperationClaimRepository _userOperationClaimRepository;

            public DeleteUserOperationClaimCommandHandler(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<DeleteUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);
                UserOperationClaim deletedUserOperationClaim = await _userOperationClaimRepository.DeleteAsync(mappedUserOperationClaim);
                DeleteUserOperationClaimDto deleteUserOperationClaim = _mapper.Map<DeleteUserOperationClaimDto>(deletedUserOperationClaim);
                return deleteUserOperationClaim;
            }
        }
    }
}
