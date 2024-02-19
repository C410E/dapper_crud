using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CrudDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace CrudDapper.Controllers 
{
    public class ProductsController : Controller
    {
        private readonly string ConnectionString = "User ID=postgres;Password=654789123;Host=localhost;Port=5432;Database=dappercrud;";

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                IDbConnection con;

                try 
                {
                    string insercaoQuery = "INSERT INTO products(name)VALUES(@Name)";
                    con = new NpgsqlConnection(ConnectionString);
                    con.Open();
                    con.Execute(insercaoQuery, products);
                    con.Close();
                    return RedirectToAction(nameof(Create));
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View(products);
        }
    }
}