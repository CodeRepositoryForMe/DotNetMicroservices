﻿using Catalog.API.Data;
using Catalog.API.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;

        public ProductRepository(ICatalogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                            .Products
                            .Find(p => true)
                            .ToListAsync();
        }

        public Task<Product> GetProduct(string id)
        {
            FilterDefinition<Product> filter =
                Builders<Product>.Filter.ElemMatch(p => p.Id, id);

            return _context
                        .Products
                        .Find(filter)
                        .FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter =
                Builders<Product>.Filter.ElemMatch(p => p.Categotry, categoryName);
            
                return await _context
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition < Product > filter =
                Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            
            return await _context
                            .Products
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await _context
                                    .Products
                                    .ReplaceOneAsync(filter: p => p.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged 
                && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var deleteResult = await _context
                                    .Products
                                    .DeleteOneAsync(filter: p => p.Id == id);

            return deleteResult.IsAcknowledged 
                && deleteResult.DeletedCount > 0;
        }
    }
}
