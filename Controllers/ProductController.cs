using AutoMapper;
using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;
using ECommAPIAssessment.Services;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ECommAPIAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public ProductController(IProductService productService, IMapper mapper, ILog logger)
        {
            this.productService = productService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet, Route("GetProductById/{productId}")]
        [AllowAnonymous]
        public IActionResult GetProductById(int productId)
        {
            try
            {
                Product product = productService.GetProductById(productId);
                ProductwithIdDTO productdto = _mapper.Map<ProductwithIdDTO>(product);
                if (productdto != null)
                {
                    return StatusCode(200, productdto);
                }
                else
                {
                    _logger.Error($"Product with Id {productId} not found");
                    return StatusCode(200, new JsonResult($"Product with Id {productId} not found"));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("ProductList")]
        [AllowAnonymous]
        public IActionResult ProductList()
        {
            try
            {
                List<Product> products = productService.GetProductList();
                List<ProductwithIdDTO> productDTOs = _mapper.Map<List<ProductwithIdDTO>>(products);
                return StatusCode(200, productDTOs);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost, Route("AddProduct")]
        [Authorize(Roles = "Supplier")]
        public IActionResult AddProduct(ProductDTO productdto)
        {
            try
            {
                var result = productService.AddProduct(productdto);
                if (result.Success)
                {
                    _logger.Info("User added successfully");
                    return StatusCode(200, productdto);
                }
                else
                {
                    _logger.Error(result.Message);
                    return StatusCode(400, result.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete, Route("DeleteProduct/{productId}")]
        [Authorize(Roles = "Supplier")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                var result = productService.DeleteProduct(productId);
                if (result.Success)
                {
                    _logger.Error($"Product with Id {productId} is deleted successfully");
                    return StatusCode(200, new JsonResult($"Product with Id {productId} is deleted successfully"));
                }
                else
                {
                    _logger.Error(result.Message);
                    return StatusCode(400, result.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPut, Route("UpdateProduct")]
        [Authorize(Roles = "Supplier")]
        public IActionResult UpdateProduct(ProductwithIdDTO productdto)
        {
            try
            {
                var result = productService.UpdateProduct(productdto);
                if (result.Success)
                {
                    _logger.Info(result.Message);
                    return StatusCode(200, result.Message);
                }
                else
                {
                    _logger.Error(result.Message);
                    return StatusCode(400, result.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }
    }
}
