using ChemQuiz.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuiz.API.Services.Implementations
{
    public class AppUserService : IAppUserService
    {
        private Models.Context.AppContext Context;

        public AppUserService(Models.Context.AppContext Context)
        {
            this.Context = Context;
        }

        public AppUser Create(AppUser user)
        {
            try
            {
                Context.Add(user);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public AppUser Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AppUser> FindAll()
        {
            throw new NotImplementedException();
        }

        public AppUser FindByID(long Id)
        {
            return Context.AppUser
                .SingleOrDefault(x => x.UserId.Equals(Id));
        }

        public AppUser FindByAuthID(string AuthId)
        {
            return Context.AppUser
                .SingleOrDefault(x => x.AuthId.Equals(AuthId));
        }

        public AppUser Update(AppUser t)
        {
            throw new NotImplementedException();
        }
    }
}
