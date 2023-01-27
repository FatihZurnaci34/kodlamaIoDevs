using Core.Persistence.Repositories;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Domain.Entities;
using Kodlama.Io.Devs.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Persistence.Repositories
{
    public class GithubAddressRepository : EfRepositoryBase<GithubProfile, BaseDbContext>, IGithubAddressRepository
    {
        public GithubAddressRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
