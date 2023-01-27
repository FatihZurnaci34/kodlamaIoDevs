using Core.Persistence.Paging;
using Kodlama.Io.Devs.Application.Features.UserOperationClaims.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.UserOperationClaims.Models
{
    public class UserOperationClaimListModel:BasePageableModel
    {
        public IList<UserOperationClaimListDto> Items { get; set; }
    }
}
