using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogManagerAPI.Domain.Entity;
using ProductCatalogManagerAPI.Persistence.Concrete;
using ProductCatalogManagerAPI.Application.Abstraction;
using ProductCatalogManagerAPI.Application.Dtos;
using AutoMapper;

namespace ProductCatalogManagerAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductCatalogController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductCatalogController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="model"> Product value model</param>
        /// <returns>Result as true or false</returns>
        [HttpPost]
        [Route("Add")]
        public async Task<bool> Add([FromBody] ProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            return await _productService.AddAsync(product);
        }

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="model">Product Value Model</param>
        /// <returns>Result as true or false</returns>
        [HttpPost]
        [Route("Update")]
        public bool Update([FromBody] ProductDto model)
        {
            var product = _mapper.Map<Product>(model);
            return _productService.Update(product);
        }

        /// <summary>
        /// Removes a product by its Id
        /// </summary>
        /// <param name="Id">Id of the product to be deleted</param>
        /// <returns>Result as true or false</returns>
        [HttpGet]
        [Route("Remove/{Id}")]
        public async Task<bool> Remove(string Id)
        {
            return await _productService.RemoveAsync(Id);
        }

        /// <summary>
        /// Gets a product by its Id
        /// </summary>
        /// <param name="Id">Id of the product</param>
        /// <returns>Related product</returns>
        [HttpGet]
        [Route("Get/{Id}")]
        public async Task<ProductDto> Get(string Id)
        {
            var product = await _productService.GetByIdAsync(Id);
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet]
        [Route("List")]
        public List<ProductDto> List()
        {
            var products = _productService.GetAll();
            return products.Select(a => _mapper.Map<ProductDto>(a)).ToList();
        }

        /// <summary>
        /// Searches products
        /// </summary>
        /// /// <<param name="query">query to be searched</param>
        /// <returns>Search result</returns>
        [HttpGet]
        [Route("Search/{query}")]
        public List<ProductDto> Search(string query)
        {
            var results = _productService.Search(query);
            return results.Select(a => _mapper.Map<ProductDto>(a)).ToList();
        }
    }
}