using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;
using ECommAPIAssessment.Model;

namespace ECommAPIAssessment.Services
{
    public interface IProductService
    {
        Product GetProductById(int productid);
        List<Product> GetProductList();
        ResultModel AddProduct(ProductDTO productdto);
        ResultModel DeleteProduct(int productid);
        ResultModel UpdateProduct(ProductwithIdDTO product);
    }
}
