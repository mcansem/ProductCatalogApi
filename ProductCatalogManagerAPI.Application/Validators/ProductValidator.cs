using FluentValidation;
using ProductCatalogManagerAPI.Application.Abstraction;
using ProductCatalogManagerAPI.Application.Dtos;
using ProductCatalogManagerAPI.Application.Repository;
using ProductCatalogManagerAPI.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductCatalogManagerAPI.Application.Validators
{
    /// <summary>
    /// Validator class for Product entity, uses ProductDto since ist usen in web requests in controller
    /// </summary>
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        /// <summary>
        /// IProductReadRepository interface
        /// </summary>
        private readonly IProductReadRepository _productReadRepository;

        /// <summary>
        /// Constructor for ProductValidator class
        /// </summary>
        /// <param name="productReadRepository">IProductReadRepository interface </param>
        public ProductValidator(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
            //Rules for Name property
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("please provide a name for product")
                .Length(5, 150).WithMessage("please provide a name between 5 to 150 for Name");

            //Rules for Code property
            RuleFor(x => x)
                .Must(IsCodeUnique).WithMessage("Code must be unique, please provide a different value");
            RuleFor(x => x.Code)
                .NotEmpty().NotNull().WithMessage("please provide a value for product code")
                .Matches("^[a-zA-Z0-9]+$").WithMessage("Code can contain only alphanumeric characters ");
            ///Rules for Price property
            RuleFor(x => x.Price).NotEmpty().NotNull().WithMessage("please provide a price for product")
            .ExclusiveBetween(0, 999).WithMessage("price should be between 0 and 999");
            ///Rules for Pictore property
            RuleFor(x => x.Picture)
                .Matches(new Regex(@"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$"))
                .WithMessage("please provide a valid url for product picture");
        }

        /// <summary>
        /// checks if product.Code is unique
        /// </summary>
        /// <param name="newEntity">entity to be added or updated</param>
        /// <returns></returns>
        private bool IsCodeUnique(ProductDto newEntity)
        {
            var values = _productReadRepository.GetAll();
            var forUpdate = values.Any(x => x.Id == newEntity.Id);
            var returnValue = false;
            //checks for update operations
            if (forUpdate)
                returnValue = values.Where(x => x.Id != newEntity.Id).All(x => x.Code != newEntity.Code);
            //checks for add operations
            else
                returnValue = values.All(x => x.Code != newEntity.Code);
            return returnValue;
        }
    }
}