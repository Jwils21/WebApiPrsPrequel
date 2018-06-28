using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPrsPrequel.Models;

namespace WebApiPrsPrequel.Controllers
{
    public class UsersController : ApiController
    {
		private WebApiPrsPrequelContext db = new WebApiPrsPrequelContext();

		[HttpGet]
		public IEnumerable<User> List() {
			return db.Users.ToList();
		}
		[HttpGet]
		public User Get(int? id) {
			if(id == null) return null;
			return db.Users.Find(id);
		}
		[HttpPost]
		public bool Create(User user) {
			if(user == null) return false;
			if(!ModelState.IsValid) return false;
			db.Users.Add(user);
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Change(User user) {
			if(user == null) return false;
			if(!ModelState.IsValid) return false;
			db.Users.Attach(user);
			db.Entry(user).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return true;
		}
		[HttpPost]
		public bool Remove(User user) {
			if(user == null) return false;
			if(!ModelState.IsValid) return false;
			db.Users.Attach(user);
			db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return true;
		}
	}
}
