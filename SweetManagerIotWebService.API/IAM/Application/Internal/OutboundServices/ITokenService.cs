﻿namespace SweetManagerIotWebService.API.IAM.Application.Internal.OutboundServices
{
    public interface ITokenService
    {
        string GenerateToken(dynamic user);

        dynamic? ValidateToken(string? token);
    }
}