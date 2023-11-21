using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;
using ECommAPIAssessment.Model;

namespace ECommAPIAssessment.Services
{
    public interface IOrderService
    {
        Order GetOrderById(Guid orderid);
        List<Order> GetOrderList();
        ResultModel PlaceOrder(OrderDTO orderdto);
        ResultModel CancelOrder(Guid orderid);
        ResultModel UpdateOrder(OrderwithIdDTO orderdto);
    }
}
