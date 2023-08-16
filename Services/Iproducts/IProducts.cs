using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;

namespace TaskManager.Services.Iproducts
{
  public interface IProducts
  {
    // logic for products
    // add a product
    // get all products
    // get a product
    // update a product
    // delete a product
    public Task<ResponseService> CreateProductAsync(Products product);
    public Task<ResponseService> AddProductAsync(AddProduct product);

    public Task<List<Products>> GetAllProductsAsync();

    public Task<Products> GetProductAsync(string id);

    public Task<ResponseService> UpdateProductAsync(Products product);

    public Task<ResponseService> DeleteProductAsync(string id);
  }
}