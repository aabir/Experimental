﻿using Microsoft.AspNetCore.Mvc;
using PostGreBE.Entity;
using PostGreBE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostGreBE.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private IRepository<Company> _companyRepo;
        public CompanyController(IRepository<Company> companyRepo)
        {
            _companyRepo = companyRepo;
        }

        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return _companyRepo.GetAll();
        }
    }
}
