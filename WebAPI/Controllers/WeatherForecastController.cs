﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IShopService _service;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IShopService service)
        {
            _logger = logger;
            _service = service;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //        {
        //            Date = DateTime.Now.AddDays(index),
        //            TemperatureC = rng.Next(-20, 55),
        //            Summary = Summaries[rng.Next(Summaries.Length)]
        //        })
        //        .ToArray();
        //}

        [HttpGet]
        public IEnumerable<Products> Get()
        {
            var q = _service.GetProductsQ(null);
            //return q.AsEnumerable();
            return q.ToArray();
        }
    }
}