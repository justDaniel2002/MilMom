using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Cart;
using Milmom_Service.Model.Response.Cart;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        //
        [Authorize(Roles = "Staff, Customer")]
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
        {
            if(request == null)
            {
                return BadRequest("Please Inplement all information!");
            }
            await _cartService.AddToCart(request.AccountId, request.ProductId);
            return Ok();
        }

        [Authorize(Roles = "Staff, Customer")]
        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart([FromBody] CartRequest request)
        {
            if (request == null)
            {
                return BadRequest("Please Inplement all information!");
            }
            await _cartService.RemoveFromCart(request.AccountId, request.ProductId);
            return Ok();
        }

        [Authorize(Roles = "Staff, Customer")]
        [HttpGet("{accountId}")]
        public async Task<ActionResult<BaseResponse<CartResponse>>> GetCart(string accountId)
        {
            if (accountId.IsNullOrEmpty())
            {
                return BadRequest("Please Input Id!");
            }
            var cart = await _cartService.GetCart(accountId);
            return Ok(cart);
        }

        [Authorize(Roles = "Staff, Customer")]
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> ClearCart(string accountId)
        {
            if (accountId.IsNullOrEmpty())
            {
                return BadRequest("Please Input Id!");
            }
            await _cartService.ClearCart(accountId);
            return Ok();
        }

        [Authorize(Roles = "Staff, Customer")]
        [HttpPut("{accountId}")]
        public async Task<ActionResult<BaseResponse<CartResponse>>> UpdateProductQuantityInCart(string accountId,int productId, int newQuantity)
        {
            if (string.IsNullOrEmpty(accountId) && productId == 0)
            {
                // Check if pageIndex is not a valid integer
                if (!int.TryParse(productId.ToString(), out _))
                {
                    return BadRequest("productId must be a valid integer.");
                }

                // Check if pageSize is not a valid integer
                if (!int.TryParse(newQuantity.ToString(), out _))
                {
                    return BadRequest("newQuantity must be a valid integer.");
                }

                // Continue with your logic if all conditions are met
                return BadRequest("Please Inplement all information!");
            }
            var cartUpdate = await _cartService.UpdateProductQuantityInCart(accountId,productId, newQuantity);
            return Ok(cartUpdate);
        }
    }
}
