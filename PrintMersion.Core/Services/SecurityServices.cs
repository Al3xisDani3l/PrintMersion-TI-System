using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;


namespace PrintMersion.Core.Services
{
   public class SecurityServices: ISecurityService
    {
        private readonly ISecurityRepositor _repository;

        public SecurityServices(ISecurityRepositor unitOfWork)
        {
            _repository = unitOfWork;
        }

        public async Task<User> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _repository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(User security)
        {
            await _repository.RegisterUser(security);
        }
    }
}
