using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {       //oracle,sql veri tabanı geliyormş gibi  simule ediyoruz
            _products = new List<Product> {
                 new Product{ProductId=1,CategoryId=1,ProductName="kalem",UnitPrice=15,UnitsInStock=15},
                 new Product{ProductId=2,CategoryId=1,ProductName="uç",UnitPrice=500,UnitsInStock=3},
                 new Product{ProductId =3, CategoryId = 2, ProductName = "silgi", UnitPrice = 1500, UnitsInStock = 2 },
                 new Product{ProductId=4,CategoryId=2,ProductName="kırmızı kalem",UnitPrice=150,UnitsInStock=65},
                 new Product{ProductId=5,CategoryId=2,ProductName="bant",UnitPrice=85,UnitsInStock=1}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product ProductToDelete = ProductToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //foreach la aynı görevi yapar 
                _products.Remove(ProductToDelete);


            //foreach (Product p in _products)
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        ProductToDelete = p;
            //    }
            //}


            //LİNQ - Leangue Integrated  Query
            //lambda =  =>  
 
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {   //gönderdiğim ürün ıd sine  sahip olan liste'dedeki  ürünü bul 
            Product ProductToUpdate = ProductToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //foreach la aynı görevi yapar 
            ProductToUpdate.ProductName = product.ProductName;
            ProductToUpdate.ProductId = product.ProductId;
            ProductToUpdate.UnitPrice = product.UnitPrice;
            ProductToUpdate.UnitsInStock = product.UnitsInStock;
            ProductToUpdate.CategoryId = product.CategoryId;
             
        }

        public List<Product> GetAllByCategory(int catogryId) 
        {
            return _products.Where(p => p.CategoryId == catogryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
