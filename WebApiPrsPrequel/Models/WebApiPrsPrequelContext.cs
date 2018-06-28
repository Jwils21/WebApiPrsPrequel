using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiPrsPrequel.Models {
	public class WebApiPrsPrequelContext: DbContext {
		public DbSet<User> Users { get; set; }
		public DbSet<Vendor> Vendors { get; set; }
		public DbSet<Product> Products { get; set; }

		public WebApiPrsPrequelContext(): base() { }
	}
}