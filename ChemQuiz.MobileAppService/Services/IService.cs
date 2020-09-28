using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuiz.API.Services
{
    public interface IService<T>
    {
        T Create(T t);
        T FindByID(long Id);
        IEnumerable<T> FindAll();
        T Update(T t);
        T Delete(long Id);
    }
}
