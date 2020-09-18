using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChemQuiz.Services
{
        public interface IService<out T, in A > 
        {
            T Create(A a);
            T FindByID(long Id);
            IEnumerable<T> FindAll();
            T Update(A a);
            T Delete(long Id);
        }
}   
