using AutoMapper;
using ECommAPIAssessment.Database;
using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;
using ECommAPIAssessment.Model;

namespace ECommAPIAssessment.Services
{
    public class OrderService : IOrderService
    {
        private readonly MyContext context;
        private readonly IMapper _mapper;

        public OrderService(MyContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public ResultModel CancelOrder(Guid orderid)
        {
            try
            {
                Order order = context.Orders.SingleOrDefault(o => o.OrderId == orderid);

                if (order != null)
                {
                    context.Remove(order);
                    context.SaveChanges();

                    return new ResultModel { Success = true, Message = "Order cancelled successfully." };
                }
                else
                {
                    return new ResultModel { Success = false, Message = "Order not found." };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public List<Order> GetOrderList()
        {
            try
            {
                return context.Orders.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Order GetOrderById(Guid orderid)
        {
            try
            {
                return context.Orders.SingleOrDefault(o => o.OrderId == orderid);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ResultModel PlaceOrder(OrderDTO orderdto)
        {
            try
            {
                Order order = _mapper.Map<Order>(orderdto);
                order.OrderId = Guid.NewGuid();
                order.OrderDate= DateTime.Now;
                order.Product = context.Products.Find(orderdto.ProductId);
                order.User = context.Users.Find(orderdto.UserId);
                context.Orders.Add(order);
                context.SaveChanges();
                return new ResultModel { Success = true, Message = "Order placed successfully." };
                
            }
            catch (Exception ex)
            {
                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }

        public ResultModel UpdateOrder(OrderwithIdDTO orderdto)
        {
            try
            {
                if (orderdto != null)
                {
                    Order order = _mapper.Map<Order>(orderdto);
                    order.Product = context.Products.Find(orderdto.ProductId);
                    order.User = context.Users.Find(orderdto.UserId);
                    context.Orders.Update(order);
                    context.SaveChanges();
                    return new ResultModel { Success = true, Message = "Oder updated successfully." };
                }
                else
                {
                    return new ResultModel { Success = false, Message = "Order not found." };
                }
            }
            catch (Exception ex)
            {

                return new ResultModel { Success = false, Message = $"Error: {ex.Message}" };
            }
        }
    }
}
