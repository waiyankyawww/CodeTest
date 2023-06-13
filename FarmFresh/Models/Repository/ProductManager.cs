using System;
using System.Collections.Generic;
using System.Linq;
using FarmFresh.DAL;

namespace FarmFresh.Models.Repository
{
	public class ProductManager : IProductRepository<Product>
	{
        readonly FarmFreshContext _context;

        public ProductManager(FarmFreshContext context)
		{
            _context = context;
		}

        public Product Get(int id)
        {

            return _context.Products.FirstOrDefault(e => e.ID == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product, Product entity)
        {
            product.ProductName = entity.ProductName;
            product.ProductPhoto = entity.ProductPhoto;
            product.ProductType = entity.ProductType;
            product.PackingType = entity.PackingType;
            product.OnSale = entity.OnSale;
            product.ShopByStore = entity.ShopByStore;
            product.CreatedDate = entity.CreatedDate;
            product.Status = entity.Status;
            _context.SaveChanges();
        }
    }
}