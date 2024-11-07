﻿using BaseCoffee.BLL.DTOs;
using BaseCoffee.BLL.Managers.Abstract;
using BaseCoffee.DAL.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BaseCoffee.UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IGenericManager<ProductDTO, Product> _productManager;
        private readonly IGenericManager<CategoryDTO, Category> _categoryManager;
        private readonly IGenericManager<OrderDTO, Order> _orderManager;
        private readonly IGenericManager<OrderDetailDTO, OrderDetail> _orderDetailManager;

        public CartController(IGenericManager<CategoryDTO, Category> categoryManager, IGenericManager<ProductDTO, Product> productManager,
            IGenericManager<OrderDTO, Order> orderManager, IGenericManager<OrderDetailDTO, OrderDetail> orderDetailManager )
        {
            _categoryManager = categoryManager;
            _productManager = productManager;
            _orderManager = orderManager;
            _orderDetailManager = orderDetailManager;
        }
        public IActionResult Index()
        {
            var prodcuts = _productManager.GetAll();
            var productDtos = prodcuts.Select(
                p => new
                {
                    p.Id,
                    p.CategoryID,
                    p.Name,
                    p.Price,
                    p.Description,
                    p.StockQuantity,
                    categoryName = _categoryManager.Find(p.CategoryID)?.Name
                }
                ).ToList();
            return View(productDtos);
        }

        public IActionResult Cart() 
        {
            return View();
        }


        [HttpPost]
        public IActionResult CompleteOrder(List<CartDTO> cart) 
        {
            if(cart ==null || !cart.Any())
            {
                return BadRequest("cart is null");
            }

            var totalAmount = cart.Sum(item => item.Quantity * _productManager.Find(item.ProductID).Price);

            var newOrder = new OrderDTO(0, DateTime.Now, totalAmount, "Created");

            var createdOrder = _orderManager.Add(newOrder);

            Response.Cookies.Append("OrderID", createdOrder.Id.ToString());

            foreach (var item in cart) 
            {

                var orderDetail = new OrderDetailDTO(0, createdOrder.Id, item.ProductID, item.Quantity, _productManager.Find(item.ProductID).Price);

                //sipariş detaylarını ekle

                _orderDetailManager.Add(orderDetail);

            }
            return Ok("Order Succes !!!");

        }
    }
}
