﻿namespace Mango.Services.CouponAPI.Models.Dto;

public class ResponseDTO
{
    public Object? Result { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; } = String.Empty;
    
}