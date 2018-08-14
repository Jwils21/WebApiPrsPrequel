using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiPrsPrequel.Models;
using WebApiPrsPrequel.Utility;

namespace WebApiPrsPrequel.Controllers
{
    public class UsersController : ApiController
    {
		private WebApiPrsPrequelContext db = new WebApiPrsPrequelContext();

		//GET-ALL
		//indicates that a get method will be used to get this info vs. post which updates
		[HttpGet]
		[ActionName("List")] //this is the name the client will use to call this method
		public JsonResponse List() {
			return new JsonResponse {
				Data = db.Users.ToList()
			};
		}

		//GET-ONE
		[HttpGet]
		[ActionName("Get")]
		public JsonResponse User (int? id) {
			if(id == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Id does not exist"
				};
			}
			return new JsonResponse {
				Data = db.Users.Find(id)
			};
		}

		//POST
		[HttpPost]
		[ActionName("Create")]
		public JsonResponse Create(User user) {
			if(user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Major"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}

			db.Users.Add(user);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Create successful.",
				Data = user
			};
		}

		//CHANGE
		[HttpPost]
		[ActionName("Change")]
		public JsonResponse Change(User user) {
			if(user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Major"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(user).State = System.Data.Entity.EntityState.Modified;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Change successful.",
				Data = user
			};
		}

		//DELETE
		[HttpPost]
		[ActionName("Remove")]
		public JsonResponse Remove(User user) {
			if(user == null) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Create requires an instance of Major"
				};
			}
			if(!ModelState.IsValid) {
				return new JsonResponse {
					Result = "Failed",
					Message = "Model state is invalid. See data.",
					Error = ModelState
				};
			}
			db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = user
			};
		}

		//REMOVE/ID
		[HttpGet]
		[ActionName("RemoveId")]
		public JsonResponse Remove(int? id) {
			if(id == null)
				return new JsonResponse {
					Result = "Failed",
					Message = "RemoveId requires a User.Id"
				};
			var user = db.Users.Find(id);
			if(user == null)
				return new JsonResponse {
					Result = "Failed",
					Message = $"No User has Id of {id}"
				};
			db.Users.Remove(user);
			db.SaveChanges();
			return new JsonResponse {
				Message = "Remove successful.",
				Data = user
			};
		}












		//[HttpGet]
		//public IEnumerable<User> List() {
		//	return db.Users.ToList();
		//}
		//[HttpGet]
		//public User Get(int? id) {
		//	if(id == null) return null;
		//	return db.Users.Find(id);
		//}
		//[HttpPost]
		//public bool Create(User user) {
		//	if(user == null) return false;
		//	if(!ModelState.IsValid) return false;
		//	db.Users.Add(user);
		//	db.SaveChanges();
		//	return true;
		//}
		//[HttpPost]
		//public bool Change(User user) {
		//	if(user == null) return false;
		//	if(!ModelState.IsValid) return false;
		//	db.Users.Attach(user);
		//	db.Entry(user).State = System.Data.Entity.EntityState.Modified;
		//	db.SaveChanges();
		//	return true;
		//}
		//[HttpPost]
		//public bool Remove(User user) {
		//	if(user == null) return false;
		//	if(!ModelState.IsValid) return false;
		//	db.Users.Attach(user);
		//	db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
		//	db.SaveChanges();
		//	return true;
		//}
	}
}
