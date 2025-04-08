using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Controllers;

[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[ApiController]
public class CouponApiController : ControllerBase
{
    private readonly AppDbContext _context;
    private ResponseDTO _response;
    private IMapper _mapper;

    public CouponApiController(AppDbContext dbContext, IMapper mapper)
    {
        _context = dbContext;
        _response = new ResponseDTO();
        _mapper = mapper;
    }

    [HttpGet]
    [Route("/api/[controller]/[action]")]
    public ResponseDTO GetAll()
    {
        try
        {
            IEnumerable<Coupon> objList = _context.Coupons.ToList();
            _response.Result = _mapper.Map<IEnumerable<CouponDTO>>(objList);
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
            _response.Result = _mapper.Map<CouponDTO>(obj);
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
    [Route("GetByCode/{code}")]
    public ResponseDTO GetByCode(String code)
    {
        try
        {
            Coupon obj = _context.Coupons.FirstOrDefault(x => x.CouponCode.ToLower().Equals(code.ToLower())) ??
                            throw new InvalidOperationException();
            if (obj == null)
            {
                _response.IsSuccess = false;
            }
            _response.Result = _mapper.Map<CouponDTO>(obj);
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
    
    [HttpPost]
    [Route("/api")]
    public ResponseDTO Post([FromBody] CouponDTO couponDTO)
    {
        try
        {
           _context.Coupons.Add(_mapper.Map<Coupon>(couponDTO));
            _context.SaveChanges();
            _response.Result = _mapper.Map<CouponDTO>(couponDTO);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }
    [HttpPut]
    [Route("/api")]
    public ResponseDTO Put([FromBody] CouponDTO couponDTO)
    {
        try
        {
           _context.Coupons.Update(_mapper.Map<Coupon>(couponDTO));
            _context.SaveChanges();
            _response.Result = _mapper.Map<CouponDTO>(couponDTO);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }    
    [HttpDelete]
    [Route("/api/{id}")]
    public ResponseDTO Delete(int id)
    {
        try
        {
            Coupon obj = _context.Coupons.FirstOrDefault(x => x.CouponId == id);
                         _context.Coupons.Remove(obj);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }

        return _response;
    }
}