using Business.BusinessRules.ProductManager.Abstract;
using Business.Contants.ResultContants;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.BusinessRules.ProductManager.Concrete
{
    public class ProductManagerRule : IProductManagerRule
    {
        private IProductDal _productDal;

        public ProductManagerRule(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public IResult CheckIfProductNameExist(string productName)
        {
            if (_productDal.Get(x => x.ProductName == productName) != null)
            {
                return new ErrorResult(ResultMessages.ProductNameAlreadyExist);
            }

            return new SuccessResult();
        }
    }
}
