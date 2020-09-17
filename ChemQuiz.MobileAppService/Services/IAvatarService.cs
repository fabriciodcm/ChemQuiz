using ChemQuiz.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuiz.API.Services
{
    public interface IAvatarService
    {
        Avatar Create(Avatar avatar);
        Avatar FindByID(long Id);
        List<Avatar> FindAll();
        Avatar Update(Avatar avatar);
        Avatar Delete(long Id);
    }
}
