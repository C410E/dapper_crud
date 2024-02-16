using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapper.Controllers 
{
    public class ProductsController : Controller
    {
        private readonly string ConnectionString = "User ID=postgres;Password=654789123;Host=localhost;Port=5432;Database=dappercrud;";

        public IActionResult Index()
        {
            return View();
        }
    }
}