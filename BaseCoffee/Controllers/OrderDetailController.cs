using BaseCoffee.BLL.DTOs;
using BaseCoffee.BLL.Managers.Abstract;
using BaseCoffee.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseCafe.UI.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IGenericManager<OrderDTO, Order> _orderManager;
        private readonly IGenericManager<ProductDTO, Product> _productManager;
        private readonly IGenericManager<CategoryDTO, Category> _categoryManager;
        private readonly IGenericManager<OrderDetailDTO, OrderDetail> _orderDetailManger;

        public OrderDetailController(IGenericManager<OrderDetailDTO, OrderDetail> orderDetailManger, IGenericManager<ProductDTO, Product> productManager, IGenericManager<CategoryDTO, Category> categoryManager, IGenericManager<OrderDTO, Order> orderManager)
        {
            _orderDetailManger = orderDetailManger;
            _categoryManager = categoryManager;
            _orderManager = orderManager;
            _productManager = productManager;
        }


        public IActionResult Index()
        {
            var orders = _orderManager.GetAll();
            var orderDetails = _orderDetailManger.GetAll();

            var orderDtos = orders.Select(order => new
            {
                order.Id,
                order.OrderDate,
                order.TotalAmount,
                order.Status,
                OrderDetails = orderDetails.Where(od => od.OrderID == order.Id).Select(od => new
                {
                    od.ProductID,
                    od.Quantity,
                    od.UnitPrice,
                    ProductName = _productManager.Find(od.ProductID)?.Name,
                    CategoryName = _categoryManager.Find(_productManager.Find(od.ProductID)?.CategoryID ?? 0)?.Name
                }).ToList()
            }).ToList();

            return View(orderDtos);
        }
    }
    /*
     orderdate,total amaount ,status, qutanity, unit price product name ,category name,
     */
}
