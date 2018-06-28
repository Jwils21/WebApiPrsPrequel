using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPrsPrequel.Models;

namespace WebApiPrsPrequel.Controllers
{
    public class ProductsController : ApiController
    {
		private WebApiPrsPrequelContext db = new WebApiPrsPrequelContext();

		[HttpGet]
		public IEnumerable<Product> List() {
			return db.Products.ToList();
		}
		[HttpGet]
		public Product Get(int? id) {
			if(id == null) return null;
			return db.Products.Find(id);
		}
		[HttpPost]
		public bool Create(Product product) {
			if(product == null) return false;
			if(!ModelState.IsValid) return false;
			db.Products.Add(product);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Change(Product product) {
			if(product == null) return false;
			if(!ModelState.IsValid) return false;
			db.Products.Attach(product);
			db.Entry(product).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Remove(Product product) {
			if(product == null) return false;
			if(!ModelState.IsValid) return false;
			db.Products.Attach(product);
			db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return true;
		}

	}
}
