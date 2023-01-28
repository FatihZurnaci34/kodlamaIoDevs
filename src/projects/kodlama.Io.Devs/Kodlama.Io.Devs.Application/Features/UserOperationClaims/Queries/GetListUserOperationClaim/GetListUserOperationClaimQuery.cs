using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Models;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery:IRequest<UserOperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserOperationClaimQueryHandler : IRequestHandler<GetListUserOperationClaimQuery, UserOperationClaimListModel>
        {
            IMapper _mapper;
            IUserOperationClaimRepository _userOperationClaimRepository;

            public GetListUserOperationClaimQueryHandler(IMapper mapper, IUserOperationClaimRepository operationClaimRepository)
            {
                _mapper = mapper;
                _userOperationClaimRepository = operationClaimRepository;
            }

            public async Task<UserOperationClaimListModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> userOperationClaim = await _userOperationClaimRepository.GetListAsync(include: a => a.Include(m => m.User).Include(m => m.OperationClaim)
                                                                                                                    , index:request.PageRequest.Page,
                                                                                                                    size:request.PageRequest.PageSize);
                UserOperationClaimListModel mappedUserOperationClaim = _mapper.Map<UserOperationClaimListModel>(userOperationClaim);
                return mappedUserOperationClaim;

            }
        }
    }
}
