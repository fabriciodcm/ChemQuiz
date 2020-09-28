using ChemQuiz.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuiz.API.Services
{
    public interface IAppUserService : IService<AppUser>
    {
        public AppUser FindByAuthID(string AuthId);
    }
}
