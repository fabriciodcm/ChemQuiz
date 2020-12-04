using ChemQuiz.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChemQuiz.API.Services.Implementations
{
    public class CategoryService : IService<Category>
    {
        private Models.Context.AppContext Context;

        public CategoryService(Models.Context.AppContext Context)
        {
            this.Context = Context;
        }
        public Category Create(Category t)
        {
            throw new NotImplementedException();
        }

        public Category Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> FindAll()  => Context.Category.ToList();
       
        public Category FindByID(long Id)
        {
            throw new NotImplementedException();
        }

        public Category Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
