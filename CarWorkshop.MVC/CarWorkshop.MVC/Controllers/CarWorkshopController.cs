﻿using CarWorkshop.Application.Services;
using CarWorkshop.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;

        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            await _carWorkshopService.Create(carWorkshop);
            return RedirectToAction(nameof(Create));
        }
    }
}
