using AutoMapper;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Dtos;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.UserOperationClaims.Queries.GetByIdUserOperationClaim
{
    public class GetByIdUserOperationClaimQuery:IRequest<UserOperationClaimGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdUserOperationClaimQueryHanlder : IRequestHandler<GetByIdUserOperationClaimQuery, UserOperationClaimGetByIdDto>
        {
            IMapper _mapper;
            IUserOperationClaimRepository _userOperationClaimRepository;

            public GetByIdUserOperationClaimQueryHanlder(IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _mapper = mapper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UserOperationClaimGetByIdDto> Handle(GetByIdUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                UserOperationClaim userOperationClaim = await _userOperationClaimRepository.GetAsync(u=>u.Id== request.Id,
                                                                                              include:a=>a.Include(m=>m.User).Include(m=>m.OperationClaim));
                UserOperationClaimGetByIdDto userOperationClaimGetByIdDto = _mapper.Map<UserOperationClaimGetByIdDto>(userOperationClaim);
                return userOperationClaimGetByIdDto;
            }
        }
    }
}
