using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPrsPrequel.Models;

namespace WebApiPrsPrequel.Controllers
{
    public class VendorsController : ApiController
    {
		private WebApiPrsPrequelContext db = new WebApiPrsPrequelContext();

		[HttpGet]
		public IEnumerable<Vendor> List() {
			return db.Vendors.ToList();
		}
		[HttpGet]
		public Vendor Get(int? id) {
			if(id == null) return null;
			return db.Vendors.Find(id);
		}
		[HttpPost]
		public bool Create(Vendor vendor) {
			if(vendor == null) return false;
			if(!ModelState.IsValid) return false;
			db.Vendors.Add(vendor);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Change(Vendor vendor) {
			if(vendor == null) return false;
			if(!ModelState.IsValid) return false;
			db.Vendors.Attach(vendor);
			db.Entry(vendor).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Remove(Vendor vendor) {
			if(vendor == null) return false;
			if(!ModelState.IsValid) return false;
			db.Vendors.Attach(vendor);
			db.Entry(vendor).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return true;
		}
	}
}
