﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Lab15._3DesigningAndCreatingARestAPI.Controllers
{
    [Route("Products")]
    [ApiController]
    [Table("Products")]
    public class ProductsController : ControllerBase
    {
        public IDbConnection Connection()
        {
            return new SqlConnection("Server=HN78Q13\\SQLEXPRESS;Database=Northwind;user id=testuser;password=abc123");
        }

        [HttpGet]
        public List<Product> AllProducts()
        {
            List<Product> products = Connection().GetAll<Product>().ToList();
            return products;
        }

        [HttpGet("{ProductName}")]
        public List<Product> Products(string productName)
        {
            List<Product> products = Connection().Query<Product>($"select * from Products where ProductName like '%{productName}%'").ToList<Product>();
            return products;
        }
    }
}
