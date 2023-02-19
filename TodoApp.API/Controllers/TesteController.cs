﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TodoApp.API.Controllers
{
    [Route("api/testes")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public TesteController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult GetVariables()
        {
            IList<string> variables = new List<string>();

            string ambiente = environment.EnvironmentName;
            string connectionString = configuration.GetSection("DatabaseConfig:ConnectionString").Value;
            string dataBaseName = configuration.GetSection("DatabaseConfig:DatabaseName").Value;
            string envTest = "Variavel: " + Environment.GetEnvironmentVariable("DatabaseName");

            variables.Add(ambiente);
            variables.Add(connectionString);
            variables.Add(dataBaseName);
            variables.Add(envTest);

            return Ok(variables);
        }
    }
}
