using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class CouponApiController : ControllerBase
{
    private readonly AppDbContext _context;
    private ResponseDTO _response;

    public CouponApiController(AppDbContext dbContext)
    {
        _context = dbContext;
        _response = new ResponseDTO();
    }

    [HttpGet]
    [Route("/api/[controller]/[action]")]
    public ResponseDTO GetAll()
    {
        try
        {
            IEnumerable<Coupon> objList = _context.Coupons.ToList();
            _response.Result = objList;
            _response.IsSuccess = true;
            _response.Message = "This return is success";
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }

    [HttpGet]
    [Route("/api/[controller]/{id:int}")]
    public ResponseDTO Get(int id)
    {
        try
        {
            Coupon obj = _context.Coupons.FirstOrDefault(x => x.CouponId == id) ??
                            throw new InvalidOperationException();
            _response.Result = obj;
            _response.IsSuccess = true;
            _response.Message = "This return is success";
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }
}