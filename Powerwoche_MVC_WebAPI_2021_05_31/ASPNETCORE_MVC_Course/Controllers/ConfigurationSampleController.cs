using ASPNETCORE_MVC_Course.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCORE_MVC_Course.Controllers
{
    public class ConfigurationSampleController : Controller
    {
        private readonly ILogger<ConfigurationSampleController> _logger;
        private readonly IConfiguration _configuration;
        private readonly SampleWebSettings _settings;

        public ConfigurationSampleController(ILogger<ConfigurationSampleController> logger, IConfiguration configuration, IOptions<SampleWebSettings> settingOptions)
        {
            _logger = logger;
            _configuration = configuration;
            _settings = settingOptions.Value;
        }

        public IActionResult Sample1()
        {
            PositionOptions positionOptions = new(); // ist das gleich wie PositionOptions positionOptions = new PositionOptions()
            _configuration.GetSection(PositionOptions.stringPosition).Bind(positionOptions);


            return View();
        }

        public IActionResult Sample2()
        {
            return View();
        }
    }
}
