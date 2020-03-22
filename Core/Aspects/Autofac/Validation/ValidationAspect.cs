using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validations.ValidationTools.FluentValidation;
using Core.Utilities.Interceptors.Autofac;
using Core.Utilities.Messages.AspectMessages;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessage.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Sample : -- ProductValidator --
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Sample : " public class ProductValidator:AbstractValidator<Product> " -- Product --
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // " public IResult Add(Product product) " -- product --
            foreach (var entity in entities) // We used foreach because for example : Add Method may have more than one Product type parameter so we must validate all parameters (type as Product)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
} 
 