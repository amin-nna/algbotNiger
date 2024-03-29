﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using algbotNiger.Models;
using Microsoft.EntityFrameworkCore;
using algbotNiger.Areas.Identity.Data;
using Microsoft.Build.Framework;

namespace algbotNiger.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult RoomsArea()
    {
        
        return PartialView();
    }

    
    public IActionResult HotelCapacity()
    {
        return PartialView();
    }

    public IActionResult GoBack()
    {
        string previousUrl = Request.Headers["Referer"].ToString();
        if (string.IsNullOrEmpty(previousUrl))
        {
            // If there is no previous page, redirect to the home page
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // Otherwise, redirect to the previous page
            return Redirect(previousUrl);
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

