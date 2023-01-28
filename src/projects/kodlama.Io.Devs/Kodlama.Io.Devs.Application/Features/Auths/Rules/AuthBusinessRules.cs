using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using Kodlama.Io.Devs.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Io.Devs.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            User? user = await _userRepository.GetAsync(u=>u.Email==email);
            if (user != null) throw new BusinessException("Mail Already Exists");
  
        }

        public async Task CheckIfEmailIsCorrect(string email)
        {
            var user = await _userRepository.GetAsync(u => u.Email == email);
            if(user==null)
                throw new BusinessException($"{email} is not a valid email");
        }
        public void CheckIfPasswordIsCorrect(string requestPassword, byte[] userPasswordHash, byte[] userPasswordSalt) 
        {

            if (!HashingHelper.VerifyPasswordHash(requestPassword, userPasswordHash, userPasswordSalt))
                throw new BusinessException("Şifre Yanlış");
        }

    }
}
