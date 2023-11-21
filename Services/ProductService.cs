using AutoMapper;
using ECommAPIAssessment.Database;
using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;
using ECommAPIAssessment.Model;

namespace ECommAPIAssessment.Services
{
    public class ProductService : IProductService
    {
        private readonly MyContext context;
        private readonly IMapper _mapper;

        public ProductService(MyContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }

        public ResultModel AddProduct(ProductDTO productdto)
        {
            try
            {
                Product product = _mapper.Map <Product>(productdto);
                User supplier=context.Users.Find(productdto.SupplierId);
                product.Supplier = supplier;
                context.Products.Add(product);
                context.SaveChanges();
                return new ResultModel { Success = true, Message = "Product added successfully." };
                
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public ResultModel DeleteProduct(int productid)
        {
            try
            {
                Product product = context.Products.SingleOrDefault(p => p.ProductId == productid);

                if (product != null)
                {
                    context.Remove(product);
                    context.SaveChanges();

                    return new ResultModel { Success = true, Message = "Product deleted successfully." };
                }
                else
                {
                    return new ResultModel { Success = false, Message = "Product not found." };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public Product GetProductById(int productid)
        {
            try
            {
                return context.Products.SingleOrDefault(p => p.ProductId == productid); ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Product> GetProductList()
        {
            try
            {
                return context.Products.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResultModel UpdateProduct(ProductwithIdDTO productdto)
        {
            try
            {
                if (productdto != null)
                {
                    Product product = _mapper.Map<Product>(productdto);
                    User supplier = context.Users.Find(productdto.SupplierId);
                    product.Supplier = supplier;
                    context.Products.Update(product);
                    context.SaveChanges();
                    return new ResultModel { Success = true, Message = "Product edited successfully." };
                }
                else
                {
                    return new ResultModel { Success = false, Message = "product not found." };
                }
            }
            catch (Exception ex)
            {

                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }
    }
}
