using Capstone7WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capstone7WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/5
        public List<string> Get()
        {
            NorthwindEntities db = new NorthwindEntities();
            List<Product> prod = db.Products.ToList();
            List<string> product = new List<string>();

            for (int i = 0; i < prod.Count; i++)
            {
                product.Add(prod[i].ProductID.ToString());
                product.Add(prod[i].ProductName);
            }

            return product;
          
        }

        public Product GetProduct(int id)
        {
            NorthwindEntities db = new NorthwindEntities();
            Product desc = db.Products.OrderBy(x => x.ProductID).First();
            int low = desc.ProductID;
            Product asc = db.Products.OrderByDescending(x => x.ProductID).First();
            int high = asc.ProductID;

            if (id <= high && id >= low)
            {
                Product prod = (from p in db.Products
                                where p.ProductID == id
                                select p).Single();

                return prod;
            }
            else
            {
                Product prod = null;
                return prod;
            }
        }

        public List<Product> GetByCategoryID(int id)
        {
            NorthwindEntities db = new NorthwindEntities();

            List<Product> prod = (from p in db.Products
                                  where p.CategoryID == id
                                  select p).ToList();

            return prod;
        }

        public List<Product> GetBySupplierID(int id)
        {
            NorthwindEntities db = new NorthwindEntities();

            List<Product> prod = (from p in db.Products
                                  where p.SupplierID == id
                                  select p).ToList();

            return prod;
        }

        public List<Product> GetMax(int amount)
        {
            NorthwindEntities db = new NorthwindEntities();

            List<Product> prod = (from p in db.Products
                                  where p.UnitPrice >= amount
                                  select p).ToList();

            return prod;
        }

        public List<Product> GetDiscontinued(int id)
        {
            NorthwindEntities db = new NorthwindEntities();

            if (id == 0)
            {
                List<Product> prod = (from p in db.Products
                                      where p.Discontinued == false
                                      select p).ToList();
                return prod;
            }
            else if(id == 1)
            {
                List<Product> prod = (from p in db.Products
                                      where p.Discontinued == true
                                      select p).ToList();
                return prod;
            }
            else
            {
                List<Product> prod = null;
                return prod;
            }
        }
    }
}
