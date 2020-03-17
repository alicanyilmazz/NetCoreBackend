using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract.EntityServices
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList();
        //IResult Add(Category category);
        //IResult Delete(Category category);
        //IResult Update(Category category);
    }
}
