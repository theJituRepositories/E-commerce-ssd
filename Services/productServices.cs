using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskManager.Models;
using TaskManager.Services.Iproducts;

namespace TaskManager.Services
{
    public class ProductServices : IProducts
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://localhost:3000/products";

        public ProductServices()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ResponseService> CreateProductAsync(Products product)
        {
            try
            {
                var content = JsonConvert.SerializeObject(product);
                var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(_url, bodyContent);

                if (response.IsSuccessStatusCode)
                {
                    return new ResponseService { Message = "Product Created Successfully" };
                }
                else
                {
                    throw new Exception($"Product Creation Failed: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Product Creation Failed: {ex.Message}");
            }
        }

        public async Task<ResponseService> DeleteProductAsync(string id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(_url + "/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return new ResponseService { Message = "Product deleted successfully" };
                }
                else
                {
                    throw new Exception($"Product Deletion Failed: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Product Deletion Failed: {ex.Message}");
            }
        }

        public async Task<Products> GetProductAsync(string id)
        {
            try
            {
                var response = await _httpClient.GetAsync(_url + "/" + id);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<Products>(content);
                    return product;
                }
                else
                {
                    throw new Exception($"Could not fetch product: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Could not fetch product: {ex.Message}");
            }
        }

        public async Task<List<Products>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var allproducts = JsonConvert.DeserializeObject<List<Products>>(content);
                    return allproducts;
                }
                else
                {
                    throw new Exception($"Could not fetch products: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Could not fetch products: {ex.Message}");
            }
        }

        public async Task<ResponseService> UpdateProductAsync(Products product)
        {
            try
            {
                var json = JsonConvert.SerializeObject(product);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await _httpClient.PutAsync(_url + "/" + product.Id, data);

                if (result.IsSuccessStatusCode)
                {
                    return new ResponseService { Message = "Product updated successfully" };
                }
                else
                {
                    throw new Exception($"Product Update Failed: {result.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Product Update Failed: {ex.Message}");
            }
        }

        public async Task<ResponseService> AddProductAsync(AddProduct product)
        {
            try
            {
                var json = JsonConvert.SerializeObject(product);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var result = await _httpClient.PostAsync(_url, data);

                if (result.IsSuccessStatusCode)
                {
                    return new ResponseService { Message = "Product added successfully" };
                }
                else
                {
                    throw new Exception($"Product Addition Failed: {result.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Product Addition Failed: {ex.Message}");
            }
        }
    }
}
