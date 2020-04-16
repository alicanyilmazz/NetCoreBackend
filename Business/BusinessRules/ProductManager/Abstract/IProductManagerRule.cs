using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.BusinessRules.ProductManager.Abstract
{
    public interface IProductManagerRule
    {
        IResult CheckIfProductNameExist(string productName);
    }
}
