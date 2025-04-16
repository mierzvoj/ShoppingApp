using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.VisualBasic;

namespace Mango.Web.Service;

public class CouponService : ICouponService
{
    private readonly IBaseService _baseService;

    public CouponService(IBaseService baseService)
    {
        _baseService = baseService;
    }

    public async Task<ResponseDTO?> GetCouponByIdAsync(int couponId)
    {
        RequestDTO requestDTO = new();
        requestDTO.ApiType = SD.ApiType.GET;
        requestDTO.Url = SD.CouponApiBase + "/api/coupon/{couponId}";
        return await _baseService.SendAsync(requestDTO);
    }

    public async Task<ResponseDTO?> GetAllCouponsAsync()
    {
        RequestDTO requestDto = new();
        requestDto.ApiType = SD.ApiType.GET;
        requestDto.Url = SD.CouponApiBase + "/api/coupon";
        return await _baseService.SendAsync(requestDto);
    }

    public async Task<ResponseDTO?> GetCouponAsync(string couponId)
    {
        RequestDTO requestDto = new();
        requestDto.ApiType = SD.ApiType.GET;
        requestDto.Url = SD.CouponApiBase + "/api/coupon/GetByCode/" + couponId;
        return  await _baseService.SendAsync(requestDto);
    }

    public async Task<ResponseDTO?> UpdateCouponAsync(CouponDTO couponDTO)
    {
        RequestDTO requestDTO = new();
        requestDTO.ApiType = SD.ApiType.PUT;
        requestDTO.Url = SD.CouponApiBase + "/api/coupon";
        requestDTO.Data = couponDTO;
        return await _baseService.SendAsync(requestDTO);
    }

    public async Task<ResponseDTO?> DeleteCouponAsync(int id)
    {
        RequestDTO requestDto = new();
        requestDto.ApiType = SD.ApiType.DELETE;
        requestDto.Url = SD.CouponApiBase + "/api/coupon/" + id;
        return await _baseService.SendAsync(requestDto);
    }

    public async Task<ResponseDTO?> CreateCouponAsync(CouponDTO couponDTO)
    {
        RequestDTO requestDto = new();
        requestDto.ApiType = SD.ApiType.POST;
        requestDto.Data = couponDTO;
        requestDto.Url = SD.CouponApiBase + "/api/coupon";
        return await _baseService.SendAsync(requestDto);
    }
}