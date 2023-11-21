using AutoMapper;
using ECommAPIAssessment.DTO;
using ECommAPIAssessment.Entities;
using ECommAPIAssessment.Services;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ECommAPIAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper _mapper;
        private readonly ILog _logger;

        public OrderController(IOrderService orderService, IMapper mapper, ILog logger)
        {
            this.orderService = orderService;
            _mapper = mapper;
            _logger = logger;
        }
        [HttpGet, Route("GetOrderById/{orderId}")]
        [AllowAnonymous]
        public IActionResult GetOrderById(Guid orderId)
        {
            try
            {
                Order order = orderService.GetOrderById(orderId);
                OrderwithIdDTO orderdto = _mapper.Map<OrderwithIdDTO>(order);
                if (orderdto != null)
                {
                    return StatusCode(200, orderdto);
                }
                else
                {
                    _logger.Error($"Order with Id {orderId} not found");
                    return StatusCode(200, new JsonResult($"Order with Id {orderId} not found"));
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet, Route("OrderList")]
        [AllowAnonymous]
        public IActionResult GetOrderList()
        {
            try
            {
                List<Order> orders = orderService.GetOrderList();
                List<OrderwithIdDTO> orderDTOs = _mapper.Map<List<OrderwithIdDTO>>(orders);
                return StatusCode(200, orderDTOs);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(400, ex.Message);
            }
        }
        [HttpPost, Route("PlaceOrder")]
        [Authorize(Roles = "User")]

        public IActionResult PlaceOrder(OrderDTO orderdto)
        {
            try
            {
                var result = orderService.PlaceOrder(orderdto);
                if (result.Success)
                {
                    _logger.Info("User added successfully");
                    return StatusCode(200, orderdto);
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
        [HttpDelete, Route("CancelOrder/{orderId}")]
        [Authorize(Roles = "User")]
        public IActionResult CancelOrder(Guid orderId)
        {
            try
            {
                var result = orderService.CancelOrder(orderId);
                if (result.Success)
                {
                    _logger.Error($"Order with Id {orderId} is cancelled successfully");
                    return StatusCode(200, new JsonResult($"Order with Id {orderId} is cancelled successfully"));
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
        [HttpPut, Route("UpdateOrder")]
        [Authorize(Roles = "User")]
        public IActionResult UpdateOrder(OrderwithIdDTO orderdto)
        {
            try
            {
                var result = orderService.UpdateOrder(orderdto);
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
