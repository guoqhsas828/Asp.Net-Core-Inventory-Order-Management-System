﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManager.Data;
using StoreManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreManager.Controllers
{
    [Authorize(Roles = Pages.MainMenu.SalesOrder.RoleName)]
    public class SalesOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            SalesOrder salesOrder = _context.SalesOrder.SingleOrDefault(x => x.Id.Equals(id));

            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }
    }
}