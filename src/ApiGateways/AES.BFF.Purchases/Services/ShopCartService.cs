﻿using AES.BFF.Purchases.Extensions;
using AES.BFF.Purchases.Models;
using AES.Core.Communication;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AES.BFF.Purchases.Services
{
    public interface IShopCartService
    {
        Task<ShopCartDTO> GetShopCart();
        Task<ResponseResult> AddItemOnShopCart(ShopCartItemDTO product);
        Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ShopCartItemDTO product);
        Task<ResponseResult> RemoveItemOnShopCart(Guid productId);
        Task<ResponseResult> ApplyVoucherOnShopCart(VoucherDTO voucher);
    }

    public class ShopCartService : Service, IShopCartService
    {
        private readonly HttpClient _httpClient;

        public ShopCartService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.ShopCartUrl);
        }

        public async Task<ShopCartDTO> GetShopCart()
        {
            var response = await _httpClient.GetAsync("/shopCart/");
            HandlingErrorsReponse(response);

            return await DeserializeObjectResponse<ShopCartDTO>(response);
        }

        public async Task<ResponseResult> AddItemOnShopCart(ShopCartItemDTO product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PostAsync("/shopCart/", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> UpdateItemOnShopCart(Guid productId, ShopCartItemDTO product)
        {
            var itemContent = GetContent(product);
            var response = await _httpClient.PutAsync($"/shopCart/{productId}", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> RemoveItemOnShopCart(Guid productId)
        {
            var response = await _httpClient.DeleteAsync($"/shopCart/{productId}");

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }

        public async Task<ResponseResult> ApplyVoucherOnShopCart(VoucherDTO voucher)
        {
            var itemContent = GetContent(voucher);

            var response = await _httpClient.PostAsync("/shopCart/appy-voucher", itemContent);

            if (!HandlingErrorsReponse(response)) return await DeserializeObjectResponse<ResponseResult>(response);

            return ReturnOk();
        }
    }
}